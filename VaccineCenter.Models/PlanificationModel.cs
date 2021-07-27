using System;

namespace VaccineCenter.Models
{
    public class PlanificationModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CenterId { get; set; }
        public int VaccinId { get; set; }
        public int PatientId { get; set; }

        public CenterModel Center { get; set; }
        public VaccinModel Vaccin { get; set; }
        public PatientModel Patient { get; set; }
    }
}