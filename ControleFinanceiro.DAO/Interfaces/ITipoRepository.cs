using ControleFinanceiro.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ITipoRepository : IRepositoryGeneric<Tipo>
    {

        new IQueryable<Tipo> GetAll();

    }
}
