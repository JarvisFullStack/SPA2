
using Entities;
using System;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public Context() : base("ConStr")
        {

        }

       
    }
}
