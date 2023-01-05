using Microsoft.EntityFrameworkCore;
using Projeto.Model;
using System.Diagnostics;

namespace Projeto.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Venda> vendas { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }

        public Contexto()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"server=localhost;Port=5432;User ID=postgres;password=1234;database=Projeto");
            optionsBuilder.UseLazyLoadingProxies();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Venda>().HasOne<Cliente>(v => v.Cliente).WithMany(c => c.Vendas).HasForeignKey(v => v.ClientID);
        //    modelBuilder.Entity<Venda>().HasOne<Produto>(v => v.Produto).WithMany(p => p.Vendas).HasForeignKey(v => v.ProdutoID);
        //}
    }
}