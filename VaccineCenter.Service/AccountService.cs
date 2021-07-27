using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using ServiceASP.template;
using System.Collections.Generic;
using System.Linq;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class AccountService : IntServices<DataContext,Account,AccountModel,AccountForm>
    {
        private AccountTypeMapper AccountTypeMapper;
        public AccountService(DataContext dc) : base(dc,new AccountMapper()) 
        {
            AccountTypeMapper = new AccountTypeMapper();
        }

        protected override AccountModel MapEntityToModel(Account target,CRUDAction action)
        {
            AccountModel account = base.MapEntityToModel(target);
            if(target.AccountType != null)
                account.AccountType = AccountTypeMapper.MapEntityToModel(target.AccountType);
            return account;
        }

        protected override Account MapModelToEntity(AccountModel model, CRUDAction action = CRUDAction.Conversion)
        {
            Account entity = base.MapModelToEntity(model, action);
            entity.AccountType = AccountTypeMapper.MapModelToEntity(model.AccountType);
            return entity;
        }

        protected override DbSet<Account> GetDbSet(DataContext dc) => dc.Accounts;
        protected override IQueryable<Account> PrepareQuery(DbSet<Account> Entity) => Entity.Include(a => a.AccountType);
    }
}
