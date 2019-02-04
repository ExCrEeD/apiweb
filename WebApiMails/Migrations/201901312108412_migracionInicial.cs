namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Correo = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacto");
        }
    }
}
