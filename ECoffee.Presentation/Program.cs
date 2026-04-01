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
            services.AddScoped<IReportQuery, ReportQuery>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // contexts
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            // services
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<PasswordHasher<User>>();
            services.AddScoped<ReportService>();
            services.AddScoped<PromotionService>();
            services.AddScoped<OrderService>();
            services.AddScoped<KdsService>();
            services.AddScoped<CategoryService>();

            // forms
            services.AddTransient<LoginForm>();
            services.AddTransient<StaffManagementForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<PromotionManagementForm>();
            services.AddTransient<ReportForm>();

            services.AddTransient<CategoryManagementForm>();
            services.AddTransient<CategoryForm>();

            // Configuration 
            services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer("Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True"));

        }
    }
}