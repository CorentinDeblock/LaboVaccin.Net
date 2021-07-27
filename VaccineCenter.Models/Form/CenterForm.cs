﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCenter.Models.Form
{
    public class CenterForm : InActivityForm
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public int ResponsibleId { get; set; }
        public int InActivityId { get; set; }
    }
}
