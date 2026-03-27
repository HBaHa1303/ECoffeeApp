using ECoffee.Application.DTOs.Response;
using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Repositories;
using ECoffee.Presentation.Forms;
using Mapster;
using Microsoft.AspNetCore.Identity;
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

            var mapster = Services.GetRequiredService<IMapster>();
            mapster.Configure();

            var loginForm = Services.GetRequiredService<LoginForm>();

            System.Windows.Forms.Application.Run(loginForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IMapster, MapsterConfiguration>();

            // services
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<PasswordHasher<User>>();


            // forms
            services.AddTransient<LoginForm>();
            services.AddTransient<StaffManagementForm>();

            // Configuration 
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True"));

        }
    }
}