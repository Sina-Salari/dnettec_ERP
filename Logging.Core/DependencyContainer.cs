using Logging.Persistence.Common.QueryUnitOfWork;
using Logging.Persistence.Common.UnitOfWork;
using Logging.Application.Logs.MappingProfiles;
using Logging.Application.Logs.Commands;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Logging.Core
{
    public static class DependencyContainer : object
    {
        static DependencyContainer()
        {
        }

        public static void ConfigureServices
            (IConfiguration configuration,
            IServiceCollection services)
        {
            // **************************************************
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(typeof(Dnettec.Logging.ILogger<>), typeof(Dnettec.Logging.NLogAdapter<>));
            // **************************************************

            // **************************************************
            services.AddMediatR
                (typeof(MappingProfile).GetTypeInfo().Assembly);

            services.AddValidatorsFromAssembly
                (typeof(CreateLogCommandValidator).Assembly);

            services.AddTransient
                (typeof(IPipelineBehavior<,>), typeof(Dnettec.Mediator.ValidationBehavior<,>));
            // **************************************************

            // **************************************************
            services.AddAutoMapper
                (typeof(MappingProfile));
            // **************************************************

            // **************************************************
            services.AddTransient<IUnitOfWork, UnitOfWork>(current =>
            {
                string databaseConnectionString =
                    configuration
                    .GetSection(key: "ConnectionStrings")
                    .GetSection(key: "CommandsConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "CommandsDatabaseProvider")
                    .Value;

                Dnettec.Persistence.Common.Provider databaseProvider =
                    (Dnettec.Persistence.Common.Provider)
                    System.Convert.ToInt32(databaseProviderString);

                Dnettec.Persistence.Common.Options options =
                    new Dnettec.Persistence.Common.Options
                    {
                        Provider = databaseProvider,
                        ConnectionString = databaseConnectionString,
                    };

                return new UnitOfWork(options);
            });
            // **************************************************

            // **************************************************
            services.AddTransient<IQueryUnitOfWork, QueryUnitOfWork>(current =>
            {
                string databaseConnectionString =
                    configuration
                    .GetSection(key: "ConnectionStrings")
                    .GetSection(key: "QueriesConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "QueriesDatabaseProvider")
                    .Value;

                Dnettec.Persistence.Common.Provider databaseProvider = (Dnettec.Persistence.Common.Provider)Convert.ToInt32(databaseProviderString);

                Dnettec.Persistence.Common.Options options = new Dnettec.Persistence.Common.Options
                {
                    Provider = databaseProvider,
                    ConnectionString = databaseConnectionString,
                };

                return new QueryUnitOfWork(options: options);
            });
            // **************************************************
        }
    }
}
