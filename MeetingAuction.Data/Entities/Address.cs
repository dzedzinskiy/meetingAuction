using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Data.Entities
{
    [Table("Address")]
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string State { get; set; }
        public string Village { get; set; }
        public string Quadrants { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; }

        public string GetAddress(IAddressFormatter format)
        {
            return format.Format(this);
        }
    }

    public class DefaultAddressFormatter : IAddressFormatter
    {
        public string Format(IAddress address)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}, {1}{2}, {3}, {4}, {5}",
                address.Country,
                address.State != null ? address.State + ", " : "",
                address.City,
                address.Street,
                address.House,
                address.ZipCode);
            string result = sb.ToString();
            return result;
        }
    }
}
