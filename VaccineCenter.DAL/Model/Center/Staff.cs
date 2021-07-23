using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.DAL.Model
{
    public class Staff : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public StaffGrade Grade { get; set; }
        public string INAMI { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
