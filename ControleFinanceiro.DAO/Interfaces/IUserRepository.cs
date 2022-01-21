using ControleFinanceiro.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IUserRepository : IRepositoryGeneric<User>
    {
        Task<int> GetAllUserRegister();
        Task<IdentityResult> AddUser(User user, string pass);
        Task IncludeUserInFunction(User user, string func);
        Task Login(User user, bool remember);
        Task PutUser(User user);
        IQueryable<User> FilterUser(string name);
        Task<User> GetUserByEmail(string email);
        Task<IList<string>> GetFunctionsUser(User user);
    }
}
