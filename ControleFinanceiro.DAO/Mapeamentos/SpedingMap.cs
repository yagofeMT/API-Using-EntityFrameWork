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
    public class SpedingMap : IEntityTypeConfiguration<Speding>
    {
        public void Configure(EntityTypeBuilder<Speding> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Amount).IsRequired();
            builder.Property(s => s.Day).IsRequired();
            builder.Property(s => s.Year).IsRequired();
            builder.Property(s => s.Amount).IsRequired();

            builder.HasOne(s => s.Card).WithMany(s => s.Spedings).HasForeignKey(s => s.CardId).IsRequired();
            builder.HasOne(s => s.Categories).WithMany(s => s.Spedings).HasForeignKey(s => s.CategoriesId).IsRequired();
            builder.HasOne(s => s.Month).WithMany(s => s.Spedings).HasForeignKey(s => s.MonthId).IsRequired();
            builder.HasOne(s => s.User).WithMany(s => s.Spedings).HasForeignKey(s => s.UserId).IsRequired();

            builder.ToTable("Spedings");
        }
    }
}
