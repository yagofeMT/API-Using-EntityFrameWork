#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using Microsoft.AspNetCore.Cors;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class CategorysController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategorysController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [Authorize (Roles = "Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryRepository.GetAll().ToListAsync();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategorys(int id)
        {
            var categorys = await _categoryRepository.GetById(id);

            if (categorys == null)
            {
                return NotFound();
            }

            return categorys;
        }


        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorys(int id, Category categorys)
        {
            if (id != categorys.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _categoryRepository.Put(categorys);

                return Ok(new
                {
                    message = $"Category {categorys.Name} Update Sucess"
                });
            }

            return BadRequest(ModelState);
        }



        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategorys(Category categorys)
        {
            if(categorys.Name.Length <= 3)
            {
                return NotFound(new
                {
                    message = $"Category {categorys.Name} Not Found"
                });
            }
            if (ModelState.IsValid)
            {
                await _categoryRepository.Insert(categorys);

                return Ok(new
                {
                    message = $"Category {categorys.Name} Update Sucess"
                });
            }

            return BadRequest(ModelState);

        }


        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorys(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }


            await _categoryRepository.DeleteById(id);

            return Ok(new
            {
                message = $"Category {category.Name} Deleted Sucess"
            });
        }


        [Authorize(Roles = "Administrador")]
        [HttpGet("FilterCategorys/{categoryName}")]
        public async Task<ActionResult<IEnumerable<Category>>> FilterCategorys(string categoryName)
        {
            return await _categoryRepository.FilterCategory(categoryName).ToListAsync();
        }
    }
}
