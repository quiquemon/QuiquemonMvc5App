namespace QuiquemonMvc5App.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logo",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(maxLength: 100),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 255),
                        Newsletter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 80),
                        OwnerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.OwnerID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Transaction = c.String(nullable: false, maxLength: 45),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Completed = c.DateTime(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.UserTeam",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.TeamID })
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logo", "ID", "dbo.User");
            DropForeignKey("dbo.UserTeam", "UserID", "dbo.User");
            DropForeignKey("dbo.UserTeam", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Payment", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Team", "OwnerID", "dbo.User");
            DropIndex("dbo.UserTeam", new[] { "TeamID" });
            DropIndex("dbo.UserTeam", new[] { "UserID" });
            DropIndex("dbo.Payment", new[] { "TeamID" });
            DropIndex("dbo.Team", new[] { "OwnerID" });
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.Logo", new[] { "ID" });
            DropTable("dbo.UserTeam");
            DropTable("dbo.Payment");
            DropTable("dbo.Team");
            DropTable("dbo.User");
            DropTable("dbo.Logo");
        }
    }
}
