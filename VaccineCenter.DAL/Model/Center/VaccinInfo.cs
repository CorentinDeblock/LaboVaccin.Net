using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class VaccinInfo
    {
        [Key]
        public int Id { get; set; }
        public uint QuantityAvailable { get; set; }
        public Vaccin Vaccin { get; set; }
    }
}
