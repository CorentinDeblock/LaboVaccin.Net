using System;
using System.Collections.Generic;
using System.Text;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models.Form
{
    public class StaffForm
    {
        public StaffGrade Grade { get; set; }
        public byte[] INAMI { get; set; }
        public string Code { get; set; }
    }
}
