
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
using FluentValidation.Validators;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using FluentValidation;
using Mc2.CrudTest.Application.Behaviors.Customers;
using FluentValidation.Results;

namespace Mc2.CrudTest.IoC;

public static class APIConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Mc2CrudTestDbContext>(options => options.UseInMemoryDatabase("Mc2CrudTestDbContext"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InjectApplication).GetTypeInfo().Assembly));

        //services.AddValidatorsFromAssembly(typeof(InjectApplication).GetTypeInfo().Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
         services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

         services.AddScoped(typeof(IPipelineBehavior<CreateCustomerCommand, ResultDto<ValidationResult>>), typeof(ValidationBehaviour<CreateCustomerCommand, ResultDto<ValidationResult>>));

        services.AddScoped(typeof(IPipelineBehavior<UpdateCustomerCommand, ResultDto<ValidationResult>>), typeof(ValidationBehaviour<UpdateCustomerCommand, ResultDto<ValidationResult>>));


        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        //services.AddScoped(typeof(IPipelineBehavior<UpdateCustomerCommand, ResultDto<ValidationResult>>),
        //   typeof(UpdateCustomerValidationBehavior<UpdateCustomerCommand, ResultDto<ValidationResult>>));

        //services.AddScoped(typeof(IPipelineBehavior<CreateCustomerCommand, ResultDto<ValidationResult>>),
        //   typeof(CreateCustomerValidationBehavior<CreateCustomerCommand, ResultDto<ValidationResult>>));
    }

}
