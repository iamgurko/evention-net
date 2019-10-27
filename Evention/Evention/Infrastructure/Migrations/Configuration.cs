using Evention.Infrastructure;
using System.Data.Entity.Migrations;

namespace Evention.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Infrastructure\Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // 

            //  DbSet<T>.AddOrUpdate() kullanarak ayn� data �retilmesi engellenir
            //  
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "G�rkan Aydo�an" },
            //      new Person { FullName = "G�rkan" },
            //      new Person { FullName = "Cansu" }
            //    );
            //
        }
    }
}
