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
    public class MonthMap : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasMany(c => c.Gains).WithOne(c => c.Month);
            builder.HasMany(c => c.Spedings).WithOne(c => c.Month);

            builder.HasData(
                new Month { Id = 1, Name = "Janeiro" },
                new Month { Id = 2, Name = "Fevereiro" },
                new Month { Id = 3, Name = "Março" },
                new Month { Id = 4, Name = "Abril" },
                new Month { Id = 5, Name = "Maio" },
                new Month { Id = 6, Name = "Junho" },
                new Month { Id = 7, Name = "Julho" },
                new Month { Id = 8, Name = "Agosto" },
                new Month { Id = 9, Name = "Setembro" },
                new Month { Id = 10, Name = "Outubro" },
                new Month { Id = 11, Name = "Novembro" },
                new Month { Id = 12, Name = "Dezembro"
            });

            builder.ToTable("Months");
        }
    }
}
