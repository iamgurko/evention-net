using System;
using System.Collections.Generic;
using System.Linq;
using Evention.Core.Dtos;
using Evention.Core.Models;
using Evention.Core.Repositories;

namespace Evention.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int eventId, string userId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.EventId == eventId && a.AttendeeId == userId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void Remove(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}