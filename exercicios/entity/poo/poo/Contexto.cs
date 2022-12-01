using Microsoft.EntityFrameworkCore;
using poo.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Email> emails { get; set; }
        public Contexto()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["EntityPostgresql"];
            String retorno = "";

            if (settings != null)
                retorno = settings.ConnectionString;

            optionsBuilder.UseNpgsql(retorno);

            optionsBuilder.UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().HasOne(e => e.Pessoa).WithMany(e => e.Emails).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
