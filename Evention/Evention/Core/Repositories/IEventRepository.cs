using System.Collections.Generic;
using Evention.Core.Models;

namespace Evention.Core.Repositories
{
    public interface IEventRepository
    {
        Event GetEvent(int eventId);
        IEnumerable<Event> GetUpcomingEventsByArtist(string artistId);
        Event GetEventWithAttendees(int eventId);
        IEnumerable<Event> GetEventsUserAttending(string userId);
        void Add(Event @event);
        IEnumerable<Event> GetUpcomingEvents(string searchTerm = null);
    }
}