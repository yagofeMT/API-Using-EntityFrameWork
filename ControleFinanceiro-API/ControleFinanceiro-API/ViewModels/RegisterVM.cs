namespace ControleFinanceiro_API.ViewModels
{
    public class RegisterVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }
        public byte[]? Photo { get; set; }
        public string CPF { get; set; }
    }
}
