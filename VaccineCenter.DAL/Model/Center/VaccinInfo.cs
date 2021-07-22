using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class VaccinInfo : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public uint QuantityAvailable { get; set; }

        public int VaccinId { get; set; }

        public Vaccin Vaccin { get; set; }
        public List<Log> Logs { get; set; }
    }
}
