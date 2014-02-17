using System.Collections.Generic;
using System.Web.Mvc;
using MeetingAuction.Data.Entities;
using MeetingAuction.Data.Interfaces;

namespace MeetingAuction.Controllers
{
    public class HomeController : Controller
    {
        private IAddressRepository _addressRepository;
        private IUserRepository _usersRepository;

        public HomeController(IAddressRepository addressRepository, IUserRepository usersRepository)
        {
            this._addressRepository = addressRepository;
            this._usersRepository = usersRepository;
        }

        [Route]
        public ActionResult Index()
        {
            Session.Add("login", "dzedzinskiy");
            return View();
        }

        [Route("{login}")]
        public ActionResult MyPage(string login)
        {
            ViewBag.Login = login;
            UsersProfile user = _usersRepository.GetUserProfileByLogin(login);
            if (user == null)
                RedirectToAction("Index");
            return View(user);
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Route("addresses")]
        public ActionResult Addresses()
        {
            IList<Address> addresses = _addressRepository.GetAddressesList();
            return View(addresses);
        }

        [Route("people")]
        public ActionResult Users()
        {
            IList<UsersProfile> users = _usersRepository.GetUsersProfiles();
            return View(users);
        }

        [AllowAnonymous]
        [Route("resource/navbar")]
        public ActionResult Navbar(bool isProfilePage = false)
        {
            var model = new NavbarViewModel
            {
                ImageLink =
                    "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT-ovtiw7JE9hNdXYuzTJotoUth6Z5JmWn7qtQgfmd8RhsRPDqN",
                IsProfilePage = isProfilePage,
                Name = "John Stephan"
            };
            return View(model);
        }
    }

    public class NavbarViewModel
    {
        public string ImageLink { get; set; }
        public string Name { get; set; }
        public bool IsProfilePage { get; set; }
    }
}