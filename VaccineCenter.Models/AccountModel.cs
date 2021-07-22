namespace VaccineCenter.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AccountTypeId { get; set; }

        public AccountTypeModel AccountType { get; set; }
    }
}
