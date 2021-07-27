using System.Collections.Generic;

namespace VaccineCenter.Models
{
    public class VaccinInfoModel
    {
        public int Id { get; set; }
        public uint QuantityAvailable { get; set; }

        public int VaccinId { get; set; }

        public VaccinModel Vaccin { get; set; }
        public List<LogModel> Logs { get; set; }
    }
}