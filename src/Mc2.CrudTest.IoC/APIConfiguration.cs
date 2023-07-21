 
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Infra.Data.Context;
using Mc2.CrudTest.Infra.Data.UnitOfWork; 
using Mc2.CrudTest.Presentation.Shared.Behaviours;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.IoC;

public static class APIConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    { 
        services.AddDbContext<Mc2CrudTestDbContext>(options => options.UseInMemoryDatabase("Mc2CrudTestDbContext"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InjectMediatR).GetTypeInfo().Assembly));
         
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

    }

}
