using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro_API.Extensions
{
    public  static class ConfigurationIdentityExtension
    {
        public static void ConfigPasswordUser(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            });
        }
    }
}
