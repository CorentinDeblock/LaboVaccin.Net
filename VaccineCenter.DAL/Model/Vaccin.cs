using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class Vaccin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Planification> Planifications { get; set; }
    }
}
