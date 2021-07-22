using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models
{
    public class StaffModel
    {
        public int Id { get; set; }
        public StaffGrade Grade { get; set; }
        public byte[] INAMI { get; set; }

        public int AccountId { get; set; }

        public AccountModel Account { get; set; }
    }
}
