using System.Data.Entity.ModelConfiguration;
using Evention.Core.Models;

namespace Evention.Infrastructure.EntityConfigurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            Property(g => g.ArtistId)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(g => g.Attendances)
                .WithRequired(a => a.Event)
                .WillCascadeOnDelete(false);
        }
        
    }
}