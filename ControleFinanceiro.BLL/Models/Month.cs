using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL.Models
{
    public class Month
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Speding> Spedings { get; set; }
        public virtual ICollection<Gain> Gains { get; set; }
    }
}
