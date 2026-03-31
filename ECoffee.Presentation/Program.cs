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

            //var loginForm = Services.GetRequiredService<LoginForm>();

            //System.Windows.Forms.Application.Run(loginForm);
            var posForm = Services.GetRequiredService<POSForm>();
            System.Windows.Forms.Application.Run(posForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IMenuRepository,MenuRepository>();

            // services
            services.AddScoped<AuthService>();
            services.AddScoped<OrderService>();

            // forms
            services.AddTransient<LoginForm>();

            // Configuration 
            //"Server=localhost,9999;Database=ECoffeeDb;User Id=sa;Password=SqlServer@2024;TrustServerCertificate=True"
            services.AddTransient<POSForm>(); // Dùng Transient để mỗi lần gọi là một Form mới hoặc SingleTon nếu muốn giữ nguyên
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=ECoffeeDb;Trusted_Connection=True;TrustServerCertificate=True"));
        }
    }
}