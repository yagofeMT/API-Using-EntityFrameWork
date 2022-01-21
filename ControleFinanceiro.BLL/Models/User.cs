using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace ControleFinanceiro.BLL.Models
{
    public class User : IdentityUser<string>
    {
        public string CPF { get; set; }
        public string Profissao { get; set; }

        [JsonProperty("Photo")]
        public byte[]? Photo  { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Gain> Gains { get; set; }
        public virtual ICollection<Speding> Spedings { get; set; }

    }
}