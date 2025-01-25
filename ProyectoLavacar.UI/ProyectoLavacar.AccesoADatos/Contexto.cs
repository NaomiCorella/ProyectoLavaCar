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
            modelBuilder.Entity<ReseniasTabla>().ToTable("Resenia");
            modelBuilder.Entity<UsuariosTabla>().ToTable("Cliente");
            modelBuilder.Entity<ServiciosTabla>().ToTable("Servicios");


        }
        public DbSet<ReservasTabla> ReservasTabla { get; set; }
        public DbSet<ReseniasTabla> ReseniasTabla { get; set; }
        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }
        public DbSet<ServiciosTabla> ServiciosTabla { get; set; }


    }
}
