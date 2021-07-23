using Microsoft.EntityFrameworkCore;
using ServiceASP.Bases;
using System.Collections.Generic;
using System.Linq;
using VaccineCenter.DAL.Model;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services.Mapper;

namespace VaccineCenter.Services
{
    public class AccountService : BaseServices<DataContext,Account, AccountModel, AccountForm, int>
    {
        private AccountTypeMapper AccountTypeMapper;
        public AccountService(DataContext dc) : base(dc,new AccountMapper()) 
        {
            AccountTypeMapper = new AccountTypeMapper();
        }

        protected override AccountModel MapEntityToModel(Account target,CRUDAction action)
        {
            AccountModel account = base.MapEntityToModel(target);
            account.AccountType = AccountTypeMapper.MapEntityToModel(target.AccountType);
            return account;
        }

        protected override DbSet<Account> GetDbSet(DataContext dc) => dc.Accounts;
        protected override IQueryable<Account> PrepareQuery(DbSet<Account> Entity) => Entity.Include(a => a.AccountType);
    }
}
