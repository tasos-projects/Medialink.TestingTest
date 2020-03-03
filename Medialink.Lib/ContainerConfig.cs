using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medialink.Database;
using Medialink.ApiClient;
using Medialink.RepositoryInterfaces;

namespace Medialink.Lib
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            try
            {
                const string baseUrl = @"http://localhost:12345/";
                SqlDatabaseDapperHelper databaseConnection = new SqlDatabaseDapperHelper(SqlDatabaseDapperHelper.Databases.Database1);


                var builder = new ContainerBuilder();

                builder.RegisterType<MathWebClient>().As<IMathWebClient>();

                builder.RegisterInstance(new RestSharpClient(baseUrl)).As<IApiClientRepository>();
                builder.RegisterInstance(new SqlDatabaseDapperLogger(databaseConnection)).As<ILoggerRepository>();

                var container = builder.Build();


                return container;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
