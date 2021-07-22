using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.DAL.Model
{
    public class Patient : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        public byte[] NationalRegistrationNumber { get; set; }
        public string MedicationIndications { get; set; }

        public int AccountId { get; set; }
        public int CommunicationId { get; set; }

        public Account Account { get; set; }
        public Communication Communication { get; set; }
        public List<Planification> Planification { get; set; }
    }
}
