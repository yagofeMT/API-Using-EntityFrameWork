using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipo = ControleFinanceiro.BLL.Models.Tipo;

namespace ControleFinanceiro.DAL
{
    public class Context : IdentityDbContext<User, Function, string>
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speding> Spedings { get; set; }
        public DbSet<Gain> Gains { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Tipo> Types { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) :base(options)
        {

        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<Context>
        {
            public Context CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GerenciadorFinanceiro;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new Context(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CardMap());
            builder.ApplyConfiguration(new CategoriesMap());
            builder.ApplyConfiguration(new FunctionMap());
            builder.ApplyConfiguration( new GainMap());
            builder.ApplyConfiguration(new SpedingMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new TipoMap());
            builder.ApplyConfiguration(new MonthMap());

        }


    }
}
