using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class AccountType : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public bool IsStaff { get; set; }
        public bool IsPatient { get; set; }
        
        public Account Account { get; set; }
    }
}
