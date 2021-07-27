using System.Collections.Generic;

namespace VaccineCenter.Models
{
    public class WorkspaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ResponsibleId { get; set; }
        public int CenterId { get; set; }

        public StaffModel Responsible { get; set; }
        public List<StaffModel> Staffs { get; set; }
        public CenterModel Center { get; set; }
    }
}