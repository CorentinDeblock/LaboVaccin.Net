using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCenter.Models.Form
{
    public class VaccinInfoForm
    {
        public uint QuantityAvailable { get; set; }

        public int VaccinId { get; set; }
        public int CenterId { get; set; }
    }
}
