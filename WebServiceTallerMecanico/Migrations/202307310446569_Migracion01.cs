namespace WebServiceTallerMecanico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vehiculo = c.String(),
                        Servicio = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                        EstadosID = c.Int(nullable: false),
                        Registro_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.EstadosID, cascadeDelete: true)
                .ForeignKey("dbo.Registroes", t => t.Registro_ID)
                .Index(t => t.EstadosID)
                .Index(t => t.Registro_ID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntregarVehiculo = c.Boolean(nullable: false),
                        PrepararCoche = c.Boolean(nullable: false),
                        DarMantenimiento = c.Boolean(nullable: false),
                        Finalizar = c.Boolean(nullable: false),
                        RecogerVehiculo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Correo = c.String(),
                        Telefono = c.String(),
                        Contrasena = c.String(),
                        Permiso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "Registro_ID", "dbo.Registroes");
            DropForeignKey("dbo.Citas", "EstadosID", "dbo.Estados");
            DropIndex("dbo.Citas", new[] { "Registro_ID" });
            DropIndex("dbo.Citas", new[] { "EstadosID" });
            DropTable("dbo.Registroes");
            DropTable("dbo.Estados");
            DropTable("dbo.Citas");
        }
    }
}
