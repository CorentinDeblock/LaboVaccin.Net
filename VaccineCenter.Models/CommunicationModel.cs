namespace VaccineCenter.Models
{
    public class CommunicationModel
    {
        public int Id { get; set; }
        public bool Phone { get; set; }
        public bool Email { get; set; }

        public int PatientId { get; set; }

    }
}