using System.Data.Entity;
using Evention.Core.Models;

namespace Evention.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Event> Events { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}