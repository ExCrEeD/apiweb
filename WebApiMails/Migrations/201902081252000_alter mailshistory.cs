namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altermailshistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailsHistorial", "RutaArchivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailsHistorial", "RutaArchivo");
        }
    }
}
