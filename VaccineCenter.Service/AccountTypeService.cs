using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class AccountTypeService : IntServices<DataContext, AccountType, AccountTypeModel, AccountTypeForm>
    {
        private AccountMapper AccountMapper;
        public AccountTypeService(DataContext dc) : base(dc,new AccountTypeMapper())
        {
            AccountMapper = new AccountMapper();
        }

        protected override AccountTypeModel MapEntityToModel(AccountType target,CRUDAction action)
        {
            AccountTypeModel acct = base.MapEntityToModel(target);
            if(acct.Account != null)
                acct.Account = AccountMapper.MapEntityToModel(target.Account);
            return acct;
        }

        protected override AccountType MapModelToEntity(AccountTypeModel model, CRUDAction action = CRUDAction.Conversion)
        {
            AccountType account = base.MapModelToEntity(model, action);
            account.Account = AccountMapper.MapModelToEntity(model.Account);
            return account;
        }

        protected override DbSet<AccountType> GetDbSet(DataContext dc)
        {
            return dc.AccountTypes;
        }
    }
}
