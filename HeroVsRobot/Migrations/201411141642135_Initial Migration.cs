namespace HeroVsRobot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ArmorBonus = c.Int(nullable: false),
                        ArmorRating = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                        DamageMaximum = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        MovesRemaining = c.Int(nullable: false),
                        Name = c.String(),
                        TrainingLevel = c.Int(nullable: false),
                        WeaponBonus = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Heroes");
        }
    }
}
