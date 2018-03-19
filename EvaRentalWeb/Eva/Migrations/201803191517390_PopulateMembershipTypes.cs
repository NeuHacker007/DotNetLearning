namespace Eva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,SignUpFee, DurationInMonth, DiscountRate) Values (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id,SignUpFee, DurationInMonth, DiscountRate) Values (2,30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id,SignUpFee, DurationInMonth, DiscountRate) Values (3,90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id,SignUpFee, DurationInMonth, DiscountRate) Values (4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
