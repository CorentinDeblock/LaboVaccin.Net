using System.Collections.Generic;

namespace VaccineCenter.Models
{
    public class VaccinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProviderId { get; set; }

        public List<PlanificationModel> Planifications { get; set; }
        public ProviderModel Provider { get; set; }
    }
}