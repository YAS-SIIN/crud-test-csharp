 
using Mc2.CrudTest.Infra.Data.UnitOfWork;
using Mc2.CrudTest.Interfaces.UnitOfWork;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.IoC;

public static class APIConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<Mc2CrudTestDbContext>(options => options.UseSqlServer(configuration["ApplicationOptions:Mc2CrudTestDbConnectionString"]));
 

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

}
