using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaccineCenter.Enum;

namespace VaccineCenter.Model
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public LogType LogType { get; set; }

        public int CenterId { get; set; }
        public int LotId { get; set; }

        public Center Center { get; set; }
        public Lot Lot { get; set; }
    }
}
