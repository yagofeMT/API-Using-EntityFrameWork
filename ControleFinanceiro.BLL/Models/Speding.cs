namespace ControleFinanceiro.BLL.Models
{
    public class Speding
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public string Description { get; set; }
        public int CategoriesId { get; set; }
        public Category Categories { get; set; }
        public double Amount { get; set; }
        public int Day { get; set; }
        public int MonthId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}