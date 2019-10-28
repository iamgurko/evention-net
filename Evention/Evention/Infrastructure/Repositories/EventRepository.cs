using Evention.Core.Models;
using Evention.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Evention.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IApplicationDbContext _context;

        public EventRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Event GetEvent(int eventId)
        {
            return _context.Events
                    .Include(g => g.Artist)
                    .Include(g => g.Genre)
                    .SingleOrDefault(g => g.Id == eventId);
        }

        public IEnumerable<Event> GetUpcomingEventsByArtist(string artistId)
        {
            return _context.Events
                .Where(g =>
                    g.ArtistId == artistId &&
                    g.DateTime > DateTime.Now &&
                    !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
        }

        public Event GetEventWithAttendees(int eventId)
        {
            return _context.Events
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == eventId);
        }

        public IEnumerable<Event> GetEventsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .Select(a => a.Event)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public void Add(Event @event)
        {
            _context.Events.Add(@event);
        }

        public IEnumerable<Event> GetUpcomingEvents(string searchTerm = null)
        {
            var upcomingEvents = _context.Events
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                upcomingEvents = upcomingEvents
                    .Where(g =>
                            g.Artist.Name.Contains(searchTerm) ||
                            g.Genre.Name.Contains(searchTerm) ||
                            g.Venue.Contains(searchTerm));
            }

            return upcomingEvents.ToList();
        }
    }
}