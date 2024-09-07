using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IRepositorys;
using Twitter.Application.IServices;
using Twitter.Application.IUnitOfWorks;
using Twitter.Application.Servecies;
using Twitter.Infrastructure.Data;
using Twitter.Infrastructure.Repository;
using Twitter.Infrastructure.UnitOfWorks;

namespace Twitter.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            string? con = configuration.GetConnectionString("DefaultSQLConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(con));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
