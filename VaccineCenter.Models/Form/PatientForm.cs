using System;

namespace VaccineCenter.Models.Form
{
    public class PatientForm : AccountForm
    {
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string NationalRegistrationNumber { get; set; }
        public string MedicationIndications { get; set; }
        public bool AllowEmailCommunication { get; set; }
        public bool AllowPhoneCommunication { get; set; }

        public int AccountId { get; set; }
        public int CommunicationId { get; set; }

    }
}