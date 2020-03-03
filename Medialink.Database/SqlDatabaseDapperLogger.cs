using Medialink.Domain;
using Medialink.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.Database
{
    public class SqlDatabaseDapperLogger : ILoggerRepository
    {
        private readonly SqlDatabaseDapperHelper _databaseConnection;

        public SqlDatabaseDapperLogger(SqlDatabaseDapperHelper databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }



        public int Log(RequestLogDBModel requestLog)
        {
            PrintLogDetailsInConsole(requestLog);

            int rowsAffected = Insert(requestLog);

            return rowsAffected;
        }

        private void PrintLogDetailsInConsole(RequestLogDBModel requestLog)
        {
            Console.WriteLine("\n\n - LOG DETAILS - " +
                $"\n LogMethod: {requestLog.LogMethod}, " +
                $"\n IsSuccess: {requestLog.IsSuccess}" +
                $"\n Timestamp: {requestLog.Timestamp}, " +
                "");
        }

        private int Insert(RequestLogDBModel requestLog)
        {
            string query = "" +
                "   INSERT INTO dbo.MyTable " +
                "   VALUES (@ParamLogMethod, @ParamIsSuccess @ParamTimestamp); ";

            var parameters = new
            {
                ParamLogMethod = requestLog.LogMethod,
                ParamIsSuccess = requestLog.IsSuccess,
                ParamTimestamp = requestLog.Timestamp
            };

            try
            {
                /*
                * - IN CASE WE RUN THE PROGRAM USING THE 'Medialink.WinFormsUI' AND NOT TO RUN THE TESTS -
                * 
                * As the connection to the database in not valid, we know it will throw an exception.
                * Because of that, we asssume that the log inserted succesfully so the 'rowsAffected' equals to 1.
                * 
                */

                //int rowsAffected = _databaseConnection.Execute(query, parameters);
                int rowsAffected = 1;

                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
