namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterEmailsHistory1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailsHistorial", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailsHistorial", "Estado");
        }
    }
}
