using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class Center
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
        public List<Vaccin> Vaccin { get; set; }
        public List<Log> Log { get; set; }
        public List<Workspace> Workspace { get; set; }
        public List<Planification> Planifications { get; set; }
    }
}
