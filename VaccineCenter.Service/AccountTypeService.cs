using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class AccountTypeService : BaseServices<DataContext,AccountType, AccountTypeModel, AccountTypeForm, int>
    {
        private AccountMapper AccountMapper;
        public AccountTypeService(DataContext dc) : base(dc,new AccountTypeMapper())
        {
            AccountMapper = new AccountMapper();
        }

        protected override AccountTypeModel MapEntityToModel(AccountType target,CRUDAction action)
        {
            AccountTypeModel acct = base.MapEntityToModel(target);
            if(action != CRUDAction.Create)
                acct.Account = AccountMapper.MapEntityToModel(target.Account);
            return acct;
        }

        protected override DbSet<AccountType> GetDbSet(DataContext dc)
        {
            return dc.AccountTypes;
        }
    }
}
