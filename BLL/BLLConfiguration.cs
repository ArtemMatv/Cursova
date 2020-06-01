using BLL.Helpers;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.IdentityModel.Tokens;
using DAL.DataStructures;
using DAL.Models;
using DAL.Interfaces;
using BLL.Interfaces;
using BLL.Services;

namespace BLL
{
    public static class BLLConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            DALConfiguration.Configure(services, configuration);

            IConfigurationSection appSettingsSection;
            if (configuration != null)
            {
                appSettingsSection = configuration.GetSection("AppSettings");
                services.Configure<AppSettings>(appSettingsSection);

                var appSettings = appSettingsSection.Get<AppSettings>();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            }

            ConfigureTransient(services);
        }

        private static void ConfigureTransient(IServiceCollection services)
        {
            services.AddTransient<IRepository<Role>, Repository<Role>>();
            services.AddTransient<IRepository<Topic>, Repository<Topic>>();

            services.AddTransient<IUnitOfWork<Comment, User>, UnitOfWork<Comment, User>>();
            services.AddTransient<IUnitOfWork<User, Post>, UnitOfWork<User, Post>>();
            services.AddTransient<IUnitOfWork<User, Role>, UnitOfWork<User, Role>>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRoleService, RoleService>();
        }
    }
}
