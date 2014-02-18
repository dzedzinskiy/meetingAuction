using System;

namespace MeetingAuction.Data.Entities
{
    public class UniversityDates
    {
        public int Id { get; set; }
        public University University { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
