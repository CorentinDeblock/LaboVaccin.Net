using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VaccineCenter.Model
{
    public class Planification
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CenterId { get; set; }
        public int VaccinId { get; set; }
        public int PatientId { get; set; }

        public Center Center { get; set; }
        public Vaccin Vaccin { get; set; }
        public Patient Patient { get; set; }
    }
}
