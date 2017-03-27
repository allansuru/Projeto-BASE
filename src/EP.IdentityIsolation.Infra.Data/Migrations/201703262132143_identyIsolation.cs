namespace EP.IdentityIsolation.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identyIsolation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImagensProduto", "FormatoImg", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImagensProduto", "FormatoImg");
        }
    }
}
