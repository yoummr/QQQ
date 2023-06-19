namespace QQQ.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class N1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Answer = c.String(),
                        Source = c.String(),
                        Ratting = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Extenstio = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        InterViewerName = c.String(),
                        DateAndTime = c.String(),
                        phone = c.String(),
                        Description = c.String(),
                        Tropics = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Contents = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interviews", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Questions", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Interviews", new[] { "ContractId" });
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropIndex("dbo.Questions", new[] { "LevelId" });
            DropTable("dbo.Events");
            DropTable("dbo.Documents");
            DropTable("dbo.Interviews");
            DropTable("dbo.Contracts");
            DropTable("dbo.Levels");
            DropTable("dbo.Questions");
            DropTable("dbo.Categories");
        }
    }
}
