using FluentValidation;
using Kernel.Persistence.Common.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kernel.Core
{
    public static class DependencyContainer
    {
        static DependencyContainer()
        {
        }

        public static void ConfigureServices
            (IConfiguration configuration, IServiceCollection services)
        {
            #region Db

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CommandConnectionString"));
            });

            services.AddDbContext<QueryDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("QueriesConnectionString"));
            });

            services.AddScoped<DapperDatabaseContext>();

            #endregion

            #region  CorsPolicy

            services.AddCors(option =>
            {
                option.AddPolicy("AllowAnyOrigin",
                item =>
                {
                    //item.WithOrigins("https://127.0.0.1:5001")
                    item.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            #endregion

            // **************************************************
            services.AddTransient
                <IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient
                (serviceType: typeof(Dnettec.Logging.ILogger<>),
                implementationType: typeof(Dnettec.Logging.NLogAdapter<>));
            // **************************************************

            // **************************************************
            services.AddMediatR
                (typeof(Application.Entities.MappingProfile).GetTypeInfo().Assembly);

            services.AddValidatorsFromAssembly
                (typeof(Application.Entities.Commands.InsertEntityCommandValidation).Assembly);

            services.AddTransient
                (typeof(IPipelineBehavior<,>), typeof(Dnettec.Mediator.ValidationBehavior<,>));
            // **************************************************

            // **************************************************
            services.AddAutoMapper
                (typeof(Application.Entities.MappingProfile));
            // **************************************************

            // **************************************************
            services.AddTransient<Persistence.Common.UnitOfWork.IUnitOfWork, Persistence.Common.UnitOfWork.UnitOfWork>(current =>
            {
                string databaseConnectionString =
                    configuration
                    .GetSection(key: "ConnectionStrings")
                    .GetSection(key: "CommandConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "CommandsDatabaseProvider")
                    .Value;

                Dnettec.Persistence.Common.Provider databaseProvider =
                    (Dnettec.Persistence.Common.Provider)Convert.ToInt32(databaseProviderString);

                Dnettec.Persistence.Common.Options options =
                    new Dnettec.Persistence.Common.Options
                    {
                        Provider = databaseProvider,
                        ConnectionString = databaseConnectionString,
                    };

                return new Persistence.Common.UnitOfWork.UnitOfWork(options: options);
            });
            // **************************************************

            // **************************************************
            services.AddTransient<Persistence.Common.QueryUnitOfWork.IQueryUnitOfWork, Persistence.Common.QueryUnitOfWork.QueryUnitOfWork>(current =>
            {
                string databaseConnectionString =
                    configuration
                    .GetSection(key: "ConnectionStrings")
                    .GetSection(key: "QueryConnectionString")
                    .Value;

                string databaseProviderString =
                    configuration
                    .GetSection(key: "QueriesDatabaseProvider")
                    .Value;

                Dnettec.Persistence.Common.Provider databaseProvider =
                    (Dnettec.Persistence.Common.Provider)Convert.ToInt32(databaseProviderString);

                Dnettec.Persistence.Common.Options options =
                    new Dnettec.Persistence.Common.Options
                    {
                        Provider = databaseProvider,
                        ConnectionString = databaseConnectionString,
                    };

                return new Persistence.Common.QueryUnitOfWork.QueryUnitOfWork(options: options);
            });
            // **************************************************
        }
    }
}
