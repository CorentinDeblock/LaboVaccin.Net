using System;

namespace VaccineCenter.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime CloseAt { get; set; }
    }
}