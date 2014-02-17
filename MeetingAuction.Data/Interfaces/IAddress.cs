namespace MeetingAuction.Data.Interfaces
{
    public interface IAddress
    {
        int Id { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string House { get; set; }
        string State { get; set; }
        string Village { get; set; }
        string Quadrants { get; set; }
        string ZipCode { get; set; }
        string PostalCode { get; set; }
        string GetAddress(IAddressFormatter format);
    }
}