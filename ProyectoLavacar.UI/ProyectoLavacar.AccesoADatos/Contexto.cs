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
            modelBuilder.Entity<InventarioTabla>().ToTable("Inventario");
            modelBuilder.Entity<EvaluacionesTabla>().ToTable("Evaluaciones");


            modelBuilder.Entity<AspNetUserRolesTabla>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<RolesTabla>().ToTable("AspNetRoles");


        }
        public DbSet<ReservasTabla> ReservasTabla { get; set; }
        public DbSet<ReseniasTabla> ReseniasTabla { get; set; }
        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }
        public DbSet<ServiciosTabla> ServiciosTabla { get; set; }
        public DbSet<EmpleadosTabla> EmpleadosTabla { get; set; }
        public DbSet<InventarioTabla> InventarioTabla { get; set; }
        public DbSet<EvaluacionesTabla> EvaluacionesTabla { get; set; }



        public DbSet<AspNetUserRolesTabla> AspNetUserRolesTabla { get; set; }
        public DbSet<RolesTabla> RolesTabla { get; set; }


    }
}
