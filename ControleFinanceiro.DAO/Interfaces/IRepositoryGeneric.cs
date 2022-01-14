using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
       IQueryable<TEntity> GetAll();

       Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);

        Task Insert(TEntity entity);

        Task Insert(List<TEntity> entity);

        Task DeleteById(int id);

        Task DeleteById(string id);

        Task Put(TEntity entity);

        Task Delete(TEntity entity);
    }
}
