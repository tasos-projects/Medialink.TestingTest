using Medialink.Domain;
using Medialink.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medialink.Lib
{
    public class MathWebClient : IMathWebClient
    {
        private IApiClientRepository _apiClient;
        private ILoggerRepository _logger;

        public MathWebClient(IApiClientRepository apiClient, ILoggerRepository logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public int Add(int a, int b)
        {
            string apiRoute = $"api/math/Add/{a}/{b}";

            try
            {
                string responseStr = _apiClient.Get(apiRoute);
                int sum = Convert.ToInt32(responseStr);

                LogRequest(apiRoute, true);

                return sum;
            }
            catch (Exception)
            {
                LogRequest(apiRoute, false);
                throw;
            }
        }

        public int Multiply(int a, int b)
        {
            string apiRoute = $"api/math/Multiply/{a}/{b}";

            try
            {
                string responseStr = _apiClient.Get(apiRoute);
                int product = Convert.ToInt32(responseStr);

                LogRequest(apiRoute, true);

                return product;
            }
            catch (Exception)
            {
                LogRequest(apiRoute, false);
                throw;
            }
        }

        public int Divide(int a, int b)
        {
            string apiRoute = $"api/math/Divide/{a}/{b}";

            try
            {
                string responseStr = _apiClient.Get(apiRoute);
                int quotient = Convert.ToInt32(responseStr);

                LogRequest(apiRoute, true);

                return quotient;
            }
            catch (Exception)
            {
                LogRequest(apiRoute, false);
                throw;
            }
        }

        private void LogRequest(string apiRoute, bool isSuccess)
        {
            RequestLogDBModel requestLog = new RequestLogDBModel
            {
                LogMethod = apiRoute,
                IsSuccess = isSuccess,
                Timestamp = DateTime.Now
            };

            try
            {
                int rowsAffected = _logger.Log(requestLog);

                PrintLogInsertResultInConsole(rowsAffected, null);
            }
            catch (Exception ex)
            {
                PrintLogInsertResultInConsole(-1, ex.Message);
                throw;
            }

        }

        private void PrintLogInsertResultInConsole(int rowsAffected, string errorMessage)
        {
            if (rowsAffected > 0)
                Console.WriteLine($"\n\nLOG ADDED TO DATABASE SUCCESSFULLY :)");
            else
                Console.WriteLine($"\n\nADD LOG TO DATABASE FAILED :( \n ERROR MESSAGE: " + errorMessage);
        }

    }
}
