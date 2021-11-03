using Microsoft.Extensions.DependencyInjection;
using OnionWebApi.Services.Services;


namespace OnionWebApi.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }                                                   
    }
}
