using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models
{
    public class StaffModel
    {
        public int Id { get; set; }
        public StaffGrade Grade { get; set; }
        public string INAMI { get; set; }
        public bool Responsible { get; set; }

        public int AccountId { get; set; }
        public int WorkspaceId { get; set; }

        public AccountModel Account { get; set; }
        public WorkspaceModel Workspace { get; set; }
    }
}
