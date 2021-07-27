namespace VaccineCenter.Models
{
    public class LotModel
    {
        public int Id { get; set; }
        public uint LotId { get; set; }

        public int VaccinId { get; set; }

        public VaccinModel Vaccin { get; set; }
    }
}