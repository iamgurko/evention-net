using System.Collections.Generic;
using Evention.Core.Models;

namespace Evention.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationsFor(string userId);
    }
}