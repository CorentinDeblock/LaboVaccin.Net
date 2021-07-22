using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class Schedule : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime CloseAt { get; set; }
        public Center Center { get; set; }
    }
}
