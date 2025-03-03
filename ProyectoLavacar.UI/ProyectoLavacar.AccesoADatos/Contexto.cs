using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos
{
    public class Contexto : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservasTabla>().ToTable("Reservas");
            modelBuilder.Entity<ReseniasTabla>().ToTable("Resenias");
            modelBuilder.Entity<UsuariosTabla>().ToTable("[AspNetUsers]");
            modelBuilder.Entity<EmpleadosTabla>().ToTable("Empleados");
            modelBuilder.Entity<ServiciosTabla>().ToTable("Servicios");
            modelBuilder.Entity<InventarioTabla>().ToTable("Producto");
            modelBuilder.Entity<EvaluacionesTabla>().ToTable("Evaluaciones");
            modelBuilder.Entity<RespuestaTabla>().ToTable("Respuesta");
            modelBuilder.Entity<MovimientoTabla>().ToTable("Movimiento");
            modelBuilder.Entity<AjustesSalarialesTabla>().ToTable("AjustesSalariales");
            modelBuilder.Entity<TramitesTabla>().ToTable("Tramites");
            modelBuilder.Entity<NominaTabla>().ToTable("Nomina");
            modelBuilder.Entity<AspNetUserRolesTabla>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<RolesTabla>().ToTable("AspNetRoles");
            modelBuilder.Entity<RebajosTabla>().ToTable("RebajosEspecificos");
            modelBuilder.Entity<RegistroHorasTabla>().ToTable("REGISTROHORAS");

        }
        public DbSet<RegistroHorasTabla> RegistroHorasTabla { get; set; }
        public DbSet<RebajosTabla> RebajosTabla { get; set; }
        public DbSet<ReservasTabla> ReservasTabla { get; set; }
        public DbSet<ReseniasTabla> ReseniasTabla { get; set; }
        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }
        public DbSet<ServiciosTabla> ServiciosTabla { get; set; }
        public DbSet<EmpleadosTabla> EmpleadosTabla { get; set; }
        public DbSet<InventarioTabla> InventarioTabla { get; set; }
        public DbSet<EvaluacionesTabla> EvaluacionesTabla { get; set; }

        public DbSet<RespuestaTabla> RespuestaTabla { get; set; }
        public DbSet<MovimientoTabla> MovimientoTabla { get; set; }

        public DbSet<AjustesSalarialesTabla> AjustesSalarialesTabla { get; set; }
        public DbSet<TramitesTabla> TramitesTabla { get; set; }
        public DbSet<NominaTabla> NominaTabla { get; set; }

        public DbSet<AspNetUserRolesTabla> AspNetUserRolesTabla { get; set; }
        public DbSet<RolesTabla> RolesTabla { get; set; }


    }
}
