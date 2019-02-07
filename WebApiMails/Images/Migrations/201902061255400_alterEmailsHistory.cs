namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterEmailsHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailsHistorial", "formato", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailsHistorial", "formato");
        }
    }
}
