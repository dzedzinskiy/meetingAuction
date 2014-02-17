using MeetingAuction.Data.Entities;

namespace MeetingAuction.Data.Interfaces
{
    public interface IAddressFormatter
    {
        string Format(IAddress address);
    }
}
