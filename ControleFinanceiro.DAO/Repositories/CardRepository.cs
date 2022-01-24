using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositories
{
    public class CardRepository : RepositoryGeneric<Card>, ICardRepository
    {
        private readonly Context _context;
        public CardRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Card> FilterCard(string name, string userid)
        {
            try
            {
                return _context.Cards.Where(c => c.Name.Contains(name)).Where(c => c.UserId == userid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Card> GetCardsUser(string UserId)
        {
            try
            {
                return _context.Cards.Where(c => c.UserId == UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
