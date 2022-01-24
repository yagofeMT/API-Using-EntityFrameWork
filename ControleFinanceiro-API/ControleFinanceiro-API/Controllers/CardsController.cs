using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Authorize(Roles = "Administrador")]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(ICardRepository cardRepository)
        {
           _cardRepository = cardRepository;
        }

       [HttpGet("GetCardsUser/{UserId}")]
       public async  Task<IEnumerable<Card>> GetCardsUser(string UserId)
       {
            return await _cardRepository.GetCardsUser(UserId).ToListAsync();
       }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            Card card = await _cardRepository.GetById(id);

            if(card == null)
            {
                return NotFound();
            }

            return card;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Card>> PutCard(int id, Card card)
        {
            if(id != card.Id)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
                await _cardRepository.Put(card);

                return Ok(new
                {
                    message = $"Card Update Sucess"
                });
            }

            return BadRequest(card);
        }


       [HttpPost]
       public async Task<ActionResult<Card>> PostCard(Card card)
       {
           if(card == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _cardRepository.Insert(card);


                return Ok(new
                {
                    message = $"Card Number ({card.Number}) Create Sucess"
                });
            }

            return BadRequest(ModelState);
       }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCard(int id)
        {

            Card card = await _cardRepository.GetById(id);

            if(card == null)
            {
                return NotFound("Card Not Exist");
            }

            _cardRepository.Delete(card);

            return Ok(new
            {
                message = $"Card Number ({card.Number}) Delete Sucess"
            });

        }

        [HttpGet("FilterCard/{name}-{userid}")]
        public async Task<ActionResult<IEnumerable<Card>>> FilterUser(string name, string userid)
        {
            if (name == null)
            {
                BadRequest();
            }

            return await _cardRepository.FilterCard(name, userid).ToListAsync();
        }

    }
}