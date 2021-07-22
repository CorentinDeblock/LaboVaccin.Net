using ServiceASP.Model;
using System;
using System.ComponentModel.DataAnnotations;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.DAL.Model
{
    public class Log : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public LogType LogType { get; set; }

        public int CenterId { get; set; }
        public int LotId { get; set; }
        public int VaccinInfoId { get; set; }

        public Center Center { get; set; }
        public Lot Lot { get; set; }
        public VaccinInfo VaccinInfo { get; set; }
    }
}
