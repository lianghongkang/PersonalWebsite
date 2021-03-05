namespace PersonalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Marriage = c.Boolean(nullable: false),
                        Tel = c.String(),
                        ResidentialAddress = c.String(),
                        NativePlace = c.String(),
                        Email = c.String(),
                        QQ = c.String(),
                        Wechat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Location = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LearningExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        School = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Major = c.String(),
                        Degree = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkingExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkingCompany = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Position = c.String(),
                        Task = c.String(),
                        WorkingLife = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkingExperiences");
            DropTable("dbo.LearningExperiences");
            DropTable("dbo.Photos");
            DropTable("dbo.PersonalInformations");
        }
    }
}
