using Evention.Core;
using Evention.Core.Models;
using Evention.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Evention.Controllers
{
    public class EventsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Details(int id)
        {
            var @event = _unitOfWork.Events.GetEvent(id);

            if (@event == null)
                return HttpNotFound();

            var viewModel = new EventDetailsViewModel { Event = @event };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending = 
                    _unitOfWork.Attendances.GetAttendance(@event.Id, userId) != null;

                viewModel.IsFollowing = 
                    _unitOfWork.Followings.GetFollowing(userId, @event.ArtistId) != null;
            }

            return View("Details", viewModel);
        }


        [Authorize]
        public ViewResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _unitOfWork.Events.GetUpcomingEventsByArtist(userId);

            return View(events);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new EventsViewModel()
            {
                UpcomingEvents = _unitOfWork.Events.GetEventsUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Katılacağım Etkinlikler",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.EventId)
            };

            return View("Events", viewModel);
        }

        [HttpPost]
        public ActionResult Search(EventsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenres(),
                Heading = "Etkinlik Ekle"
            };

            return View("EventForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var @event = _unitOfWork.Events.GetEvent(id);

            if (@event == null)
                return HttpNotFound();

            if (@event.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new EventFormViewModel
            {
                Heading = "Etkinlik Düzenle",
                Id = @event.Id,
                Genres = _unitOfWork.Genres.GetGenres(),
                Date = @event.DateTime.ToString("d MMM yyyy"),
                Time = @event.DateTime.ToString("HH:mm"),
                Genre = @event.GenreId,
                Venue = @event.Venue
            };

            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("EventForm", viewModel);
            }

            var @event = new Event
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _unitOfWork.Events.Add(@event);
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Events");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("EventForm", viewModel);
            }

            var @event = _unitOfWork.Events.GetEventWithAttendees(viewModel.Id);

            if (@event == null)
                return HttpNotFound();

            if (@event.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            @event.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);
            
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Events");
        }
    }
}