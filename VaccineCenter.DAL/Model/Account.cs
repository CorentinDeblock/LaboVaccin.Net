using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.Enum;

namespace VaccineCenter.Model
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountType AccountType { get; set; }
        public int MainAccountId { get; set; }
    }
}
