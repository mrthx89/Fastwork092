namespace E4Storage.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtyMinMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TInventor", "QtyMin", c => c.Double());
            AlterColumn("dbo.TInventor", "QtyMax", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TInventor", "QtyMax", c => c.String());
            AlterColumn("dbo.TInventor", "QtyMin", c => c.String());
        }
    }
}
