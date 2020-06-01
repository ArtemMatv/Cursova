using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class DALConfiguration
    {
        static public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForumContext>(service =>
                service.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
