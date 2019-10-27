using System.Data.Entity.Migrations;

namespace Evention.Migrations
{
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                {
                    EventId = c.Int(nullable: false),
                    AttendeeId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.EventId, t.AttendeeId })
                .Index(t => t.EventId)
                .Index(t => t.AttendeeId);
            AddForeignKey("dbo.Attendances", "EventId", "dbo.Events", "Id");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "EventId", "dbo.Events");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "EventId" });
            DropTable("dbo.Attendances");
        }
    }
}
