using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiMails.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiMails.Contexto
{
    public class DataStore : DbContext
    {

        public DataStore()
            : base("DataStore")
        {

        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Correo> Correos { get; set; }
        public DbSet<EmailsHistorial> EmailHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}