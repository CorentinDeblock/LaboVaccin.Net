using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class Workspace
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ResponsibleId { get; set; }

        public Staff Responsible { get; set; }
        public List<Staff> Staffs { get; set; }
    }
}
