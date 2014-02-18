using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAuction.Data.Entities
{
    public class UserImage
    {
        public int Id { get; set; }
        public bool IsLocal { get; set; }
        public int? ServerId { get; set; }
        public string Url { get; set; }
        public string RelativeUrl { get; set; }
        public string Type { get; set; }

        [ForeignKey("ServerId")]
        public Server Server { get; set; }
    }
}
