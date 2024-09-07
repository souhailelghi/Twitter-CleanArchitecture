using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Features.Users.Queryies.GetListUserQuery;
using Twitter.Application.IServices;
using Twitter.Application.Servecies;
//using Twitter.Application.Servecies.UnitOfServices;

namespace Twitter.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //configuration of mediator
            services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IUnitOfService, UnitOfService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
