using Evention.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Evention.Infrastructure.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Event);
        }
    }
}