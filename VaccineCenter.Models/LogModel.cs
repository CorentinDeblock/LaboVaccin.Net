using System;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models
{
    public class LogModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public LogType LogType { get; set; }

        public int CenterId { get; set; }
        public int LotId { get; set; }
        public int VaccinInfoId { get; set; }

        public CenterModel Center { get; set; }
        public LotModel Lot { get; set; }
        public VaccinInfoModel VaccinInfo { get; set; }
    }
}