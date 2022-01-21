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
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(b => b.Flag).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Number).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Number).IsUnique();
            builder.Property(c => c.Limite).IsRequired();

            builder.HasOne(c => c.User).WithMany(c => c.Cards).HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Spedings).WithOne(c => c.Card).IsRequired();

            builder.ToTable("Cards");
        }
    }
}
