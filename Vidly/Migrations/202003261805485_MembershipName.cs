namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("Update MembershipTypes Set MembershipName='Not a Member' where Id=1 ");
            Sql("Update MembershipTypes Set MembershipName='Silver' where Id=2 ");
            Sql("Update MembershipTypes Set MembershipName='Gold' where Id=3 ");
            Sql("Update MembershipTypes Set MembershipName='Daimond' where Id=4 ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
