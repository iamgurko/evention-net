using System.Collections.Generic;
using Evention.Core.Models;

namespace Evention.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int eventId, string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}