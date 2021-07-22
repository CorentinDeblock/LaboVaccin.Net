namespace VaccineCenter.Models
{
    public class AccountTypeModel
    {
        public int Id { get; set; }
        public bool IsStaff { get; set; }
        public bool IsPatient { get; set; }

        public int AccountId { get; set; }

        public AccountModel Account { get; set; }
    }
}
