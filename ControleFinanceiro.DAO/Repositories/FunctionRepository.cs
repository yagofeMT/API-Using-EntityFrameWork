﻿using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.DAL.Repositories
{
    public class FunctionRepository : RepositoryGeneric<Function>, IFunctionRepository
    {
        private readonly Context _context;
        private readonly RoleManager<Function> _ManagerFunction;
        public FunctionRepository(Context context, RoleManager<Function> manager) : base(context)
        {
            _context = context;
            _ManagerFunction = manager;
        }

        public async Task AddFunction(Function function)
        {
            try
            {
                await _ManagerFunction.CreateAsync(function);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Function> FilterFunction(string name)
        {
            try
            {
                var functions = _ManagerFunction.Roles.Where(f => f.Name.Contains(name));
                return functions;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PutFunction(Function function)
        {
            try
            {
                Function f = await GetById(function.Id);
                f.Name = function.Name;
                f.NormalizedName = function.NormalizedName;
                f.Description = function.Description;

                await _ManagerFunction.UpdateAsync(f);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
