using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositories
{
    public class UserRepository : RepositoryGeneric<User>, IUserRepository
    {
        private readonly Context _context;
        private readonly UserManager<User> _ManagerUser;
        private readonly SignInManager<User> _ManagerLogin;

        public UserRepository(Context context, UserManager<User> manager, SignInManager<User> signInManager) : base(context)
        {
            _context = context;
            _ManagerUser = manager;
            _ManagerLogin = signInManager;
        }

        public async Task<IdentityResult> AddUser(User user, string pass)
        {
            try
            {
               return await _ManagerUser.CreateAsync(user, pass);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<User> FilterUser(string name)
        {
            try
            {
                var users = _context.Users.Where(u => u.UserName.Contains(name));
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetAllUserRegister()
        {
            try
            {
                return await _context.Users.CountAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task IncludeUserInFunction(User user, string func)
        {
            try
            {
                await _ManagerUser.AddToRoleAsync(user, func);
             }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Login(User user, bool remember)
        {
            try
            {
                await _ManagerLogin.SignInAsync(user, remember);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutUser(User user)
        {
            try
            {
                User us = await GetById(user.Id);
                us.CPF = user.CPF;
                us.Email = user.Email;
                us.Photo = user.Photo;
                us.Profissao = user.Profissao;
                us.UserName = user.UserName;
                us.PhoneNumber = user.PhoneNumber;
                us.PasswordHash = user.PasswordHash;

                await _ManagerUser.UpdateAsync(us);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await _ManagerUser.FindByEmailAsync(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IList<string>> GetFunctionsUser(User user)
        {
            try
            {
                return await _ManagerUser.GetRolesAsync(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
