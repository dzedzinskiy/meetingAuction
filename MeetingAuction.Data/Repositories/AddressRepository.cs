using System.Collections.Generic;
using System.Linq;
using MeetingAuction.Data.DataContexts;
using MeetingAuction.Data.Entities;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressesDbContext db = new AddressesDbContext();

        public IList<Address> GetAddressesList()
        {
            var addressRepository = new Repository<Address>(db);
            var addresses = addressRepository.GetAll().ToList();
            return addresses;
        }
    }
}
