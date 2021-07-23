using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VaccineCenter.Models;

namespace VaccineCenter.ASP.Controllers.Emcriptor
{
    public static class UserEncryptor
    {
        private static string fieldName = "Account";

        public static void EncryptAccount(this ISession Session, AccountModel model)
        {
            Session.Set(fieldName, System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
        }

        public static AccountModel DecrypAccount(this ISession Session)
        {
            return JsonConvert.DeserializeObject<AccountModel>(Session.GetString(fieldName));
        }

        public static bool HasAccount(this ISession Session)
        {
            return Session.GetString(fieldName) != null;
        }
    }
}
