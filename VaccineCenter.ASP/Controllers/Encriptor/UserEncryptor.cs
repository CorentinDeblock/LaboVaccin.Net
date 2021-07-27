using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VaccineCenter.Models;

namespace VaccineCenter.ASP.Controllers.Emcriptor
{
    public static class UserEncryptor
    {
        private static string accountFieldName = "Account";
        private static string staffFieldName = "Staff";
        private static string accountTypeFieldName = "AccountType";

        public static void EncryptStaff(this ISession Session, StaffModel model)
        {
            Session.SetString(staffFieldName, JsonConvert.SerializeObject(model));
            Session.SetString(accountFieldName, JsonConvert.SerializeObject(model.Account));
            Session.SetString(accountTypeFieldName, JsonConvert.SerializeObject(model.Account.AccountType));
        }

        public static AccountModel DecryptAccount(this ISession Session)
        {
            return JsonConvert.DeserializeObject<AccountModel>(Session.GetString(accountFieldName));
        }

        public static StaffModel DecryptStaff(this ISession Session)
        {
            return JsonConvert.DeserializeObject<StaffModel>(Session.GetString(staffFieldName));
        }

        public static AccountTypeModel DecryptAccountType(this ISession Session)
        {
            return JsonConvert.DeserializeObject<AccountTypeModel>(Session.GetString(accountTypeFieldName));
        }

        public static bool HasAccount(this ISession Session)
        {
            return Session.GetString(accountFieldName) != null;
        }
    }
}
