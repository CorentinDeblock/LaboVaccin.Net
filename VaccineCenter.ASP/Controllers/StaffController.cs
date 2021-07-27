using Microsoft.AspNetCore.Mvc;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.ASP.Controllers.Emcriptor;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.ASP.Controllers
{
    public class StaffController : Controller
    {

        IIntService<Account, AccountModel, AccountForm> AccountServices;
        IIntService<AccountType, AccountTypeModel, AccountTypeForm> AccountTypeServices;
        IIntService<Staff, StaffModel, StaffForm> StaffServices;
        IIntService<Center, CenterModel, CenterForm> CenterServices;
        IIntService<Workspace, WorkspaceModel, WorkspaceForm> WorkspaceServices;

        public StaffController(IIntService<Account, AccountModel, AccountForm> accountServices, IIntService<AccountType, AccountTypeModel, AccountTypeForm> accountTypeServices, IIntService<Staff, StaffModel, StaffForm> staffServices, IIntService<Center, CenterModel, CenterForm> centerServices, IIntService<Workspace, WorkspaceModel, WorkspaceForm> workspaceServices)
        {
            AccountServices = accountServices;
            AccountTypeServices = accountTypeServices;
            StaffServices = staffServices;
            CenterServices = centerServices;
            WorkspaceServices = workspaceServices;
        }

        public IActionResult MyAccount()
        {
            StaffModel staff = HttpContext.Session.DecryptStaff();
            staff.Workspace.Center = CenterServices.Get(staff.Workspace.CenterId);
            return View(staff);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                using (SHA256 enc = SHA256.Create())
                {
                    byte[] password = enc.ComputeHash(Encoding.UTF8.GetBytes(form.Password));

                    AccountModel acc = AccountServices.GetFromFunc(a => a.Email == form.Email && a.Password.SequenceEqual(password));
                    if (acc != null)
                    {
                        StaffModel staff = StaffServices.Get(acc.Id);
                        
                        if (staff != null)
                        {
                            staff.Account = acc;
                            HttpContext.Session.EncryptStaff(staff);
                            return Redirect("/");
                        }

                        ViewData["Error"] = "No staff account";
                        return View(form);
                    }
                }

                ViewData["Error"] = "Wrong credential or account not created";
                return View(form);
            }

            ViewData["Error"] = "Please fill all the required field";
            return View(form);
        }

        public IActionResult Create()
        {
            StaffForm accountForm = new StaffForm();
            accountForm.Centers = CenterServices.Get().ToList();
            return View(accountForm);
        }

        [HttpPost]
        public IActionResult Create([FromForm] StaffForm accountForm)
        {
            if (ModelState.IsValid)
            {
                accountForm.WorkspaceId = WorkspaceServices.GetFromFunc(w => w.CenterId == accountForm.CenterId).Id;
                AccountModel acc;

                if (AccountServices.Has(accountForm))
                {
                    acc = AccountServices.Get(accountForm);
                    acc.AccountType.IsStaff = true;
                    AccountServices.Save();
                }
                else
                {
                    AccountTypeModel model = AccountTypeServices.Insert(new AccountTypeForm
                    {
                        isStaff = true,
                        isPatient = false
                    });

                    accountForm.AccountTypeId = model.Id;
                    acc = AccountServices.Insert(accountForm);
                }

                accountForm.AccountId = acc.Id;
                HttpContext.Session.EncryptStaff(StaffServices.Insert(accountForm));

                return RedirectToAction("Index","Home");
            }
            ViewData["Error"] = "Error on the server. Please contact us on tikiwinki@gmail.com";
            return View();
        }
    }
}
