using Evention.Core;
using Evention.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Evention.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var upcomingEvents = _unitOfWork.Events.GetUpcomingEvents(query);

            var userId = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.EventId);

            var viewModel = new EventsViewModel
            {
                UpcomingEvents = upcomingEvents,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Yaklaşan Etkinlikler",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Events", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hakkında.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim.";

            return View();
        }
    }
}