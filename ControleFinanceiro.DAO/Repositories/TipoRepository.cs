using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositories
{
    public class TipoRepository : RepositoryGeneric<Tipo>, ITipoRepository
    {
        private readonly Context _context;

        public TipoRepository(Context context) : base(context)
        {
            _context = context;
        }


        public new  IQueryable<Tipo> GetAll()
        {
            try
            {
                return _context.Types.Include(t => t.Categories);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
