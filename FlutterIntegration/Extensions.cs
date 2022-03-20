using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FlutterIntegration.Data;
using FlutterIntegration.Core;

namespace FlutterIntegration
{
    public static class Extensions
    {
        public static void AddServices(IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient();
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
