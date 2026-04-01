using ECoffee.Application.Models;
using ECoffee.Application.Repositories;
using ECoffee.Application.Services;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Repositories;
using ECoffee.Presentation.Forms;
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

            MapsterConfiguration.Configure();
            var userContext = Services.GetRequiredService<IUserContext>();
            while (true)
            {
                var loginForm = Services.GetRequiredService<LoginForm>();
                var result = loginForm.ShowDialog();

                if (result != DialogResult.OK || !userContext.IsAuthenticated)
                    break;

                var mainForm = Services.GetRequiredService<MainForm>();
                System.Windows.Forms.Application.Run(mainForm);

                if (userContext.IsAuthenticated)
                    break;
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // contexts
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            // services
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<MenuService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<PasswordHasher<User>>();


            // forms
            services.AddTransient<LoginForm>();
            services.AddTransient<StaffManagementForm>();
            services.AddTransient<MenuManagementForm>();
            services.AddTransient<PaymentManagementForm>();
            services.AddTransient<MainForm>();

            // Configuration 
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=ECoffeeDb;Trusted_Connection=True;TrustServerCertificate=True"));

        }
    }
}