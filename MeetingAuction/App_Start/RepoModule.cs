using System.Web;
using MeetingAuction.Data.Entities;
using MeetingAuction.Data.Interfaces;
using MeetingAuction.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MeetingAuction.App_Start
{
    internal class RepoModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            this.Bind<IAddressRepository>().To<AddressRepository>();
            this.Bind<IAddress>().To<Address>();
            this.Bind<IUsersProfile>().To<UsersProfile>();
        }
    }
}