using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class Vaccin : IModel<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProviderId { get; set; }

        public List<Planification> Planifications { get; set; }
        public Provider Provider { get; set; }
    }
}
