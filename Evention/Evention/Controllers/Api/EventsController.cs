using Evention.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Evention.Controllers.Api
{
    [Authorize]
    public class EventsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var @event = _unitOfWork.Events.GetEventWithAttendees(id);

            if (@event == null || @event.IsCanceled)
                return NotFound();

            if (@event.ArtistId != userId)
                return Unauthorized();

            @event.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
