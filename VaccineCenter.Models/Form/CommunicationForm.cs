using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCenter.Models.Form
{
    public class CommunicationForm
    {
        public bool Phone { get; set; }
        public bool Email { get; set; }

        public int PatientId { get; set; }
    }
}
