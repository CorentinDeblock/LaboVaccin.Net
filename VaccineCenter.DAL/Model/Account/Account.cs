using ServiceASP.Model;
using System.ComponentModel.DataAnnotations;

namespace VaccineCenter.DAL.Model
{
    public class Account : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AccountTypeId { get; set; }
        
        public AccountType AccountType { get; set; }
    }
}
