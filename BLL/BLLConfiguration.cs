using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BLLConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DALConfiguration.Configure(services, configuration);
        }

        private static void ConfigureTransient(IServiceCollection services)
        {

        }
    }
}
