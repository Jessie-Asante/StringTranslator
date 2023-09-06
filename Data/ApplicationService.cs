using StringConverter.Data.Interfaces;
using StringConverter.Data.Repositories;

namespace StringConverter.Data
{
    public static class ApplicationService
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStringConverterRepository, StringConverterRepository> ();

            return services;
        }
    }
}
