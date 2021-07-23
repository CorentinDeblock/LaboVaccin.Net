using System.ComponentModel.DataAnnotations;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models.Form
{
    public class AccountForm : StaffForm
    {
        [Required()]
        public string Email { get; set; }
        [Required()]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountTypeId { get; set; }
    }
}
