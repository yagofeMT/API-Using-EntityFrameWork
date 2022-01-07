using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tipo = ControleFinanceiro.BLL.Models.Tipo;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.Name).IsRequired();

            builder.HasMany(t => t.Categories).WithOne(t => t.Type);

            builder.HasData(new Tipo
            {
                Id = 1,
                Name = "Despesa"
            },
            new Tipo
            {
                Id = 2,
                Name = "Ganho"
            });
            builder.ToTable("Types");
        }

    }
}
