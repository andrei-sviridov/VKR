namespace VKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kompetenzia",
                c => new
                    {
                        id_kompetenzia = c.Int(nullable: false, identity: true),
                        nazvaine_kompetenzia = c.String(maxLength: 25, unicode: false),
                        opisanie_kompetenzia = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.id_kompetenzia);
            
            CreateTable(
                "dbo.sotrudnik_kompetenzia",
                c => new
                    {
                        id_sotrudnik_kompetenzia = c.Int(nullable: false, identity: true),
                        id_sotrudnik = c.Int(nullable: false),
                        id_kompetenzia = c.Int(nullable: false),
                        ozenka_sotrudnik_kompetenzia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_sotrudnik_kompetenzia)
                .ForeignKey("dbo.kompetenzia", t => t.id_kompetenzia, cascadeDelete: true)
                .ForeignKey("dbo.sotrudnik", t => t.id_sotrudnik, cascadeDelete: true)
                .Index(t => t.id_sotrudnik)
                .Index(t => t.id_kompetenzia);
            
            CreateTable(
                "dbo.sotrudnik",
                c => new
                    {
                        id_sotrudnik = c.Int(nullable: false, identity: true),
                        fio_sotrudnik = c.String(maxLength: 50, unicode: false),
                        doljnost_sotrudnik = c.String(maxLength: 30, unicode: false),
                        login_sotrudnik = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        parol_sotrudnik = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id_sotrudnik);
            
            CreateTable(
                "dbo.zadacha",
                c => new
                    {
                        id_zadacha = c.Int(nullable: false, identity: true),
                        id_sotrudnik = c.Int(),
                        opisanie_zadacha = c.String(maxLength: 150, unicode: false),
                        id_ispolnitel_zadacha = c.Int(),
                        srok_ispolnenia_zadacha = c.DateTime(nullable: false),
                        komentarii_zadacha = c.String(maxLength: 200, unicode: false),
                        status_zadacha = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_zadacha)
                .ForeignKey("dbo.sotrudnik", t => t.id_sotrudnik)
                .Index(t => t.id_sotrudnik);
            
            CreateTable(
                "dbo.zadacha_kompetenzia",
                c => new
                    {
                        id_zadacha_kompetenzia = c.Int(nullable: false, identity: true),
                        id_zadacha = c.Int(nullable: false),
                        id_kompetenzia = c.Int(nullable: false),
                        yroven_zadacha_kompetenzia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_zadacha_kompetenzia)
                .ForeignKey("dbo.kompetenzia", t => t.id_kompetenzia, cascadeDelete: true)
                .ForeignKey("dbo.zadacha", t => t.id_zadacha, cascadeDelete: true)
                .Index(t => t.id_zadacha)
                .Index(t => t.id_kompetenzia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.zadacha_kompetenzia", "id_zadacha", "dbo.zadacha");
            DropForeignKey("dbo.zadacha_kompetenzia", "id_kompetenzia", "dbo.kompetenzia");
            DropForeignKey("dbo.zadacha", "id_sotrudnik", "dbo.sotrudnik");
            DropForeignKey("dbo.sotrudnik_kompetenzia", "id_sotrudnik", "dbo.sotrudnik");
            DropForeignKey("dbo.sotrudnik_kompetenzia", "id_kompetenzia", "dbo.kompetenzia");
            DropIndex("dbo.zadacha_kompetenzia", new[] { "id_kompetenzia" });
            DropIndex("dbo.zadacha_kompetenzia", new[] { "id_zadacha" });
            DropIndex("dbo.zadacha", new[] { "id_sotrudnik" });
            DropIndex("dbo.sotrudnik_kompetenzia", new[] { "id_kompetenzia" });
            DropIndex("dbo.sotrudnik_kompetenzia", new[] { "id_sotrudnik" });
            DropTable("dbo.zadacha_kompetenzia");
            DropTable("dbo.zadacha");
            DropTable("dbo.sotrudnik");
            DropTable("dbo.sotrudnik_kompetenzia");
            DropTable("dbo.kompetenzia");
        }
    }
}
