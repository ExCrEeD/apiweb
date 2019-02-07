namespace WebApiMails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacto", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacto", "Estado", c => c.Boolean(nullable: false));
        }
    }
}
