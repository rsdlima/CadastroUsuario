using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuario.api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroUsuario.api.Data
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(l => l.Nome)
                .HasColumnType("nvarchar(200)")
                .IsRequired();

            builder
                .Property(l => l.Email)
                .HasColumnType("nvarchar(100)").IsRequired();

            builder
                .Property(l => l.DataNascimento)
                .HasColumnType("date").IsRequired();

            builder
                .Property(l => l.Senha)
                .HasColumnType("nvarchar(30)");

            builder
                .Property(l => l.Ativo)
                .HasColumnType("bit").HasDefaultValue(true);

            builder
               .Property(l => l.SexoId)
               .HasColumnType("int").IsRequired();

        }
    }
}