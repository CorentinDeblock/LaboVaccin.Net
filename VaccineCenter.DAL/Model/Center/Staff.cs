using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.Enum;

namespace VaccineCenter.Model
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public StaffGrade Grade { get; set; }
        public byte[] INAMI { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
