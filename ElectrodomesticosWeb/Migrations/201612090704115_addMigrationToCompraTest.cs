namespace ElectrodomesticosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMigrationToCompraTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.DetalleProductoes", "ImagenId", "dbo.Imagens");
            DropForeignKey("dbo.DetalleProductoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.DetalleCompras", "DetalleProductoId", "dbo.DetalleProductoes");
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropIndex("dbo.DetalleProductoes", new[] { "ImagenId" });
            DropIndex("dbo.DetalleProductoes", new[] { "ProductoId" });
            DropIndex("dbo.DetalleCompras", new[] { "CompraId" });
            DropIndex("dbo.DetalleCompras", new[] { "DetalleProductoId" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Categorias");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleProductoes");
            DropTable("dbo.Imagens");
            DropTable("dbo.Compras");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        TotalCompra = c.Single(nullable: false),
                        CompraId = c.Int(),
                        DetalleProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false),
                        NumTarjeta = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        ImagenId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagenId);
            
            CreateTable(
                "dbo.DetalleProductoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        marca = c.String(),
                        cantidad = c.Int(nullable: false),
                        precio = c.Single(nullable: false),
                        ImagenId = c.Int(),
                        ProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.DetalleCompras", "DetalleProductoId");
            CreateIndex("dbo.DetalleCompras", "CompraId");
            CreateIndex("dbo.DetalleProductoes", "ProductoId");
            CreateIndex("dbo.DetalleProductoes", "ImagenId");
            CreateIndex("dbo.Productoes", "CategoriaId");
            AddForeignKey("dbo.DetalleCompras", "DetalleProductoId", "dbo.DetalleProductoes", "Id");
            AddForeignKey("dbo.DetalleCompras", "CompraId", "dbo.Compras", "Id");
            AddForeignKey("dbo.DetalleProductoes", "ProductoId", "dbo.Productoes", "Id");
            AddForeignKey("dbo.DetalleProductoes", "ImagenId", "dbo.Imagens", "ImagenId");
            AddForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias", "Id");
        }
    }
}
