using System.Collections.Generic;
using Evention.Core.Models;

namespace Evention.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsFor(string userId);
    }
}