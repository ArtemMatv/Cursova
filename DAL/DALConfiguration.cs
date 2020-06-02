using DAL.DataStructures;
using DAL.Interfaces;
using DAL.Models;
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

            ConfigureTransient(services);
        }

        private static void ConfigureTransient(IServiceCollection services)
        {
            services.AddTransient<IRepository<Role>, Repository<Role>>();
            services.AddTransient<IRepository<Topic>, Repository<Topic>>();

            services.AddTransient<IUnitOfWork<Comment, User>, UnitOfWork<Comment, User>>();
            services.AddTransient<IUnitOfWork<User, Post>, UnitOfWork<User, Post>>();
            services.AddTransient<IUnitOfWork<User, Role>, UnitOfWork<User, Role>>();
        }
    }
}
