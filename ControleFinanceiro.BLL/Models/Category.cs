namespace ControleFinanceiro.BLL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icone { get; set; }
        public int TypeId { get; set; }
        public Tipo Type { get; set; }

        public virtual ICollection<Speding> Spedings { get; set; }
        public virtual ICollection<Gain> Gains { get; set; }
    }
}