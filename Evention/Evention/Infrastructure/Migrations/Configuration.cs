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

            //  DbSet<T>.AddOrUpdate() kullanarak ayný data üretilmesi engellenir
            //  
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Gürkan Aydoðan" },
            //      new Person { FullName = "Gürkan" },
            //      new Person { FullName = "Cansu" }
            //    );
            //
        }
    }
}
