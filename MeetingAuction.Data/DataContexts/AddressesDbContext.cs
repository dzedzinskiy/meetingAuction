using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.DataContexts
{
    public class AddressesDbContext : DbContext
    {
        public AddressesDbContext()
            : base("DefaultConnection")
        {
        }
        public IDbSet<Address> Addresses { get; set; }
    }
}
