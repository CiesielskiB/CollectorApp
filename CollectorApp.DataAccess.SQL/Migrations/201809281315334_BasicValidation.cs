namespace CollectorApp.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BorrowedSubjects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "Publisher", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Publisher", c => c.String());
            AlterColumn("dbo.Subjects", "Genre", c => c.String());
            AlterColumn("dbo.Subjects", "Title", c => c.String());
            AlterColumn("dbo.BorrowedSubjects", "Name", c => c.String());
        }
    }
}
