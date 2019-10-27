using Evention.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Evention.Infrastructure.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.EventId, a.AttendeeId });
        }
    }
}