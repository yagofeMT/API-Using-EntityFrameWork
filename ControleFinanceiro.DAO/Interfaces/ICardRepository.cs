using ControleFinanceiro.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICardRepository : IRepositoryGeneric<Card>
    {

        IQueryable<Card> GetCardsUser(string UserId);
    }
}
