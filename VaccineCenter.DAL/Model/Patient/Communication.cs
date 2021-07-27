using ServiceASP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCenter.DAL.Model
{
    public class Communication : IModel<int>
    {
        public int Id { get; set; }
        public bool Phone { get; set; }
        public bool Email { get; set; }

        public Patient Patient { get; set; }
    }
}
