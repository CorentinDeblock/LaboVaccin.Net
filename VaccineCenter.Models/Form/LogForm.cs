using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCenter.DAL.Enum;

namespace VaccineCenter.Models.Form
{
    public class LogForm
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public LogType LogType { get; set; }
        public uint LotID { get; set; }
        public bool ReferenceVaccin { get; set; }

        public int CenterId { get; set; }
        public int LotId { get; set; }
        public int VaccinInfoId { get; set; }

        public List<VaccinInfoModel> vaccinModels { get; set; }
    }
}
