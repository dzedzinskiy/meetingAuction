using System.Collections.Generic;
using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IAddressRepository
    {
        IList<Address> GetAddressesList();
    }
}
