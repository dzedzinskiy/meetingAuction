using System.Collections.Generic;

namespace MeetingAuction.Data.Entities
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public string BloodGroup { get; set; }
        public string LastBloodPressure { get; set; }
        public ICollection<Sickness> SicknessHistory { get; set; }
    }
}
