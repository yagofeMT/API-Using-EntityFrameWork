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
    public class GainMap : IEntityTypeConfiguration<Gain>
    {
        public void Configure(EntityTypeBuilder<Gain> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Description).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Amount).IsRequired();
            builder.Property(s => s.Day).IsRequired();
            builder.Property(s => s.Year).IsRequired();
            builder.Property(s => s.Amount).IsRequired();

            builder.HasOne(s => s.Categories).WithMany(s => s.Gains).HasForeignKey(s => s.CategoriesId).IsRequired();
            builder.HasOne(s => s.Month).WithMany(s => s.Gains).HasForeignKey(s => s.MonthId).IsRequired();
            builder.HasOne(s => s.User).WithMany(s => s.Gains).HasForeignKey(s => s.UserId).IsRequired();

            builder.ToTable("Gains");
        }
    }
}
