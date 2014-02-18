using System;

namespace MeetingAuction.Data.Entities
{
    public class SchoolDates
    {
        public int Id { get; set; }
        public School School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
