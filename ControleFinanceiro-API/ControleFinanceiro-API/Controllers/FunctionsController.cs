﻿using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using ControleFinanceiro_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize(Roles = "Administrador")]
    public class FunctionsController : ControllerBase
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionsController(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Function>>> GetFunctions()
        {
            return await _functionRepository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Function>> GetFunctionById(string id)
        {
            var function = await _functionRepository.GetById(id);

            if (function == null)
            {
                return NotFound();
            }

            return function;
        }

        [HttpGet("FilterFunctions/{name}")]
        public async Task<ActionResult<IEnumerable<Function>>> FilterFunction(string name)
        {
            if (name == null)
            {
                BadRequest();
            }

            return await _functionRepository.FilterFunction(name).ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunction(string id, FunctionsViewModel function)
        {
            if (id != function.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Function func = new Function { Id = function.Id, Name = function.Name, Description = function.Description };

                await _functionRepository.PutFunction(func);

                return Ok(new
                {
                    message = $"Function {func.Name} Put Sucess"
                });

            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult<Function>> PostFunction(FunctionsViewModel function)
        {
            if (ModelState.IsValid)
            {
                Function func = new Function { Name = function.Name, Description = function.Description };

                await _functionRepository.AddFunction(func);

                return Ok(new
                {
                    message = $"Function {func.Name} Add Sucess"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Function>> DeleteFunction(string id)
        {

            Function function = await _functionRepository.GetById(id);

            if (function == null)
            {
                return NotFound();
            }
            await _functionRepository.Delete(function);

            return Ok(new
            {
                message = $"Function {function.Name} Delete Sucess"
            });
        }
    }
}
