using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Presentation
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            ConfigureServices(services);

            Services = services.BuildServiceProvider();

            var loginForm = Services.GetRequiredService<LoginForm>();

            System.Windows.Forms.Application.Run(loginForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // services
            services.AddScoped<AuthService>();


            // forms
            services.AddTransient<LoginForm>();

            // Configuration 
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True"));
        }
    }
}