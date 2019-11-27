
using Entities;
using System;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Acceso_Empresa> Acceso_Empresa { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public Contexto() : base("ConStr")
        {

        }

       
    }
}
