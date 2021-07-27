using System;
using System.Collections.Generic;

namespace VaccineCenter.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string NationalRegistrationNumber { get; set; }
        public string MedicationIndications { get; set; }

        public int AccountId { get; set; }
        public int CommunicationId { get; set; }

        public AccountModel Account { get; set; }
        public CommunicationModel Communication { get; set; }
        public List<PlanificationModel> Planification { get; set; }
    }
}