namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailsHistorial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        De = c.String(),
                        Para = c.String(),
                        Asunto = c.String(),
                        Cc = c.String(),
                        Bcc = c.String(),
                        Mensaje = c.String(),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailsHistorial");
        }
    }
}
