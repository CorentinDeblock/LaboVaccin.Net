using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class InActivity : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }

        public Center Center { get; set; }
    }
}
