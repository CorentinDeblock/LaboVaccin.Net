using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class Workspace : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int CenterId { get; set; }

        public List<Staff> Staffs { get; set; }
        public Center Center { get; set; }
    }
}
