using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class FunctionMap : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Description).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Function
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Description = "Admintrador do sistema"
                },
                new Function
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Description = "Usuario do sistema"
                });

            builder.ToTable("Functions");

        }
    }
}
