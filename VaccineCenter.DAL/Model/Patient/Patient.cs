using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.Enum;

namespace VaccineCenter.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        public byte[] NationalRegistrationNumber { get; set; }
        public CommunicationType CommunicationType { get; set; }
        public string MedicationIndications { get; set; }

        public int AccountId { get; set; }
        
        public Account Account { get; set; }
        public List<Planification> Planification { get; set; }
    }
}
