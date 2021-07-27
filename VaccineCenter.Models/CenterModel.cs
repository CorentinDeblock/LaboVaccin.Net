using System.Collections.Generic;

namespace VaccineCenter.Models
{
    public class CenterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ResponsibleId { get; set; }
        public int InActivityId { get; set; }

        public InActivityModel InActivity { get; set; }
        public StaffModel Responsible { get; set; }
        public List<ScheduleModel> Schedule { get; set; }
        public List<VaccinInfoModel> Vaccin { get; set; }
        public List<LogModel> Log { get; set; }
        public List<WorkspaceModel> Workspace { get; set; }
        public List<PlanificationModel> Planifications { get; set; }
    }
}