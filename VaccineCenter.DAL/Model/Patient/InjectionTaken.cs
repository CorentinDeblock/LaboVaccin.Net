using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class InjectionTaken
    {
        [Key]
        public int Id { get; set; }

        public int StaffId { get; set; }

        public Planification Planifications { get; set; }
        public Staff Staff { get; set; }
    }
}
