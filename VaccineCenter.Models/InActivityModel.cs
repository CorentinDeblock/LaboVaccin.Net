using System;

namespace VaccineCenter.Models
{
    public class InActivityModel
    {
        public int Id { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }

        public CenterModel Center { get; set; }
    }
}