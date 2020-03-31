using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.api.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasKey(u => new { u.Id });
            modelBuilder.Entity<Usuario>().HasOne(s => s.Sexo);

            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration<Sexo>(new SexoConfiguration());
        }
    }
}
