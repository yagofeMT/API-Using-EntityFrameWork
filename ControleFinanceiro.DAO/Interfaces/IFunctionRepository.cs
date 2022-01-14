using ControleFinanceiro.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IFunctionRepository: IRepositoryGeneric<Function>
    {
        Task AddFunction(Function function);
        Task PutFunction(Function function);
        IQueryable<Function> FilterFunction(string name);
    }
}
