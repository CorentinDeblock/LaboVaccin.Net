using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class Center : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ResponsibleId { get; set; }
        public int InActivityId { get; set; }

        public InActivity InActivity { get; set; }
        public Staff Responsible { get; set; }
        public List<Schedule> Schedule { get; set; }
        public List<VaccinInfo> Vaccin { get; set; }
        public List<Log> Log { get; set; }
        public List<Workspace> Workspace { get; set; }
        public List<Planification> Planifications { get; set; }
        [NotMapped]
        public Dictionary<string, VaccinInfo> VaccinDic {
            get {
                Dictionary<string, VaccinInfo> vaccinMapping = new Dictionary<string, VaccinInfo>();

                foreach (VaccinInfo v in Vaccin)
                    vaccinMapping.Add(v.Vaccin.Name, v);

                return vaccinMapping;
            }
        }
    }
}
