namespace KurumsalWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 50),
                        Yetki = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Icerik = c.String(),
                        ResimURL = c.String(),
                        KategoriId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Kategori", t => t.KategoriId)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Hakkimizda",
                c => new
                    {
                        HakkimizdaId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HakkimizdaId);
            
            CreateTable(
                "dbo.Hizmet",
                c => new
                    {
                        HizmetId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 150),
                        Aciklama = c.String(),
                        ResimURL = c.String(),
                    })
                .PrimaryKey(t => t.HizmetId);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimId = c.Int(nullable: false, identity: true),
                        Adres = c.String(nullable: false, maxLength: 300),
                        Telefon = c.String(nullable: false, maxLength: 300),
                        Fax = c.String(),
                        Whatsapp = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                    })
                .PrimaryKey(t => t.IletisimId);
            
            CreateTable(
                "dbo.Kimlik",
                c => new
                    {
                        KimlikId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 2000),
                        Keywords = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        LogoURL = c.String(),
                        Unvan = c.String(),
                    })
                .PrimaryKey(t => t.KimlikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "KategoriId", "dbo.Kategori");
            DropIndex("dbo.Blog", new[] { "KategoriId" });
            DropTable("dbo.Kimlik");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Hizmet");
            DropTable("dbo.Hakkimizda");
            DropTable("dbo.Kategori");
            DropTable("dbo.Blog");
            DropTable("dbo.Admin");
        }
    }
}
