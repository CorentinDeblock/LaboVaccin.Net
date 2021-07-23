using ServiceASP.Bases;
using System.Security.Cryptography;
using System.Text;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class AccountMapper : IMapper<Account, AccountModel, AccountForm>
    {
        public AccountModel MapEntityToModel(Account entity)
        {
            return new AccountModel
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                AccountTypeId = entity.AccountTypeId
            };
        }

        public AccountForm MapModelToForm(AccountModel model)
        {
            return new AccountForm
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = "",
                AccountTypeId = model.AccountTypeId
            };
        }

        public Account MapFormToEntity(AccountForm form)
        {
            return new Account
            {
                Email = form.Email,
                Password = EncryptPassword(form.Password),
                FirstName = form.FirstName,
                LastName = form.LastName,
                AccountTypeId = form.AccountTypeId
            };
        }

        public Account MapModelToEntity(AccountModel model)
        {
            return new Account
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                AccountTypeId = model.AccountTypeId,
                AccountType = new AccountTypeMapper().MapModelToEntity(model.AccountType),
            };
        }

        private byte[] EncryptPassword(string password)
        {
            using (SHA256 enc = SHA256.Create())
            {
                return enc.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
