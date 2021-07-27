using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.API.Controllers
{
    internal class JwtAccount
    {
        public string Token { get; set; }
        public AccountModel Account { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly JWTSettings jwtSettings;

        IIntService<Account, AccountModel, AccountForm> AccountServices;
        IIntService<Patient, PatientModel, PatientForm> PatientServices;
        IIntService<AccountType, AccountTypeModel, AccountTypeForm> AccountTypeServices;
        IIntService<Communication, CommunicationModel, CommunicationForm> CommunicationServices;

        public PatientController(IOptions<JWTSettings> jwtSettings, IIntService<Account, AccountModel, AccountForm> accountServices, IIntService<Patient, PatientModel, PatientForm> patientServices, IIntService<AccountType, AccountTypeModel, AccountTypeForm> accountTypeServices, IIntService<Communication, CommunicationModel, CommunicationForm> communicationServices)
        {
            this.jwtSettings = jwtSettings.Value;
            AccountServices = accountServices;
            PatientServices = patientServices;
            AccountTypeServices = accountTypeServices;
            CommunicationServices = communicationServices;
        }

        [HttpPost("[action]")]
        public IActionResult Connect(LoginForm form)
        {
            try
            {
                using (SHA256 enc = SHA256.Create())
                {
                    byte[] password = enc.ComputeHash(Encoding.UTF8.GetBytes(form.Password));

                    AccountModel acc = AccountServices.GetFromFunc(a => a.Email == form.Email && a.Password.SequenceEqual(password));

                    if (acc is null) return StatusCode(StatusCodes.Status401Unauthorized, "L'email et le mot de passe ne correspondent à aucun profil.");

                    CreateUserToken(new JwtAccount { Account = acc });

                    if (acc != null)
                    {
                        PatientModel patient = PatientServices.Get(acc.Id);
                        if (patient != null)
                        {
                            patient.Account = acc;
                            return Ok(patient);
                        }
                    }
                    return StatusCode(StatusCodes.Status401Unauthorized, "Vous n'etes pas un patient");
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] PatientForm accountForm)
        {
            try
            {
                AccountModel acc;

                if (AccountServices.Has(accountForm))
                {
                    acc = AccountServices.Get(accountForm);
                    acc.AccountType.IsPatient = true;
                    AccountServices.Save();
                }
                else
                {
                    AccountTypeModel model = AccountTypeServices.Insert(new AccountTypeForm
                    {
                        isStaff = false,
                        isPatient = true
                    });

                    accountForm.AccountTypeId = model.Id;
                    acc = AccountServices.Insert(accountForm);
                }

                accountForm.AccountId = acc.Id;

                CommunicationModel communication = CommunicationServices.Insert(new CommunicationForm
                {
                    Email = accountForm.AllowEmailCommunication,
                    Phone = accountForm.AllowPhoneCommunication,
                });

                accountForm.CommunicationId = communication.Id;
                PatientModel patient = PatientServices.Insert(accountForm);
                patient.Communication = communication;

                return Ok(patient);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        private void CreateUserToken(JwtAccount account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim (ClaimTypes.Name, account.Account.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            account.Token = tokenHandler.WriteToken(token);
        }
    }
}
