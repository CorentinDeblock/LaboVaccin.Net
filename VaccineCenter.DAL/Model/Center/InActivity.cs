using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.Model
{
    public class InActivity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }

        public int CenterId { get; set; }

        public Center Center { get; set; }
    }
}
