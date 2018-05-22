namespace AngularWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusQuoteAndValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Status", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Tasks", "Quote", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Tasks", "QuoteType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tasks", "Contact", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Tasks", "Task", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Tasks", "TaskType", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tasks", "Task", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Tasks", "Contact", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Tasks", "QuoteType", c => c.String(maxLength: 50));
            DropColumn("dbo.Tasks", "Quote");
            DropColumn("dbo.Tasks", "Status");
        }
    }
}
