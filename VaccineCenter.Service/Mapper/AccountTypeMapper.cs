using ServiceASP.Bases;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;

namespace VaccineCenter.Services.Mapper
{
    public class AccountTypeMapper : IMapper<AccountType, AccountTypeModel, AccountTypeForm>
    {
        public AccountTypeModel MapEntityToModel(AccountType target)
        {
            return new AccountTypeModel
            {
                Id = target.Id,
                IsStaff = target.IsStaff,
                IsPatient = target.IsPatient
            };
        }

        public AccountType MapFormToEntity(AccountTypeForm form)
        {
            return new AccountType
            {
                IsPatient = form.isPatient,
                IsStaff = form.isStaff
            };
        }

        public AccountType MapModelToEntity(AccountTypeModel model)
        {
            return new AccountType
            {
                IsPatient = model.IsPatient,
                IsStaff = model.IsStaff
            };
        }

        public AccountTypeForm MapModelToForm(AccountTypeModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
