using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medialink.Api.Controllers
{
    public class MathController : ApiController
    {
        private static bool IsAuthorizedAccess(HttpRequestMessage request, KeyValuePair<string, string> tokens)
        {
            string myHeaderKey = tokens.Key;
            string myHeaderValue = tokens.Value;


            string userHeaderValue = string.Empty;
            if (request.Headers.TryGetValues(myHeaderKey, out IEnumerable<string> outHeaderVALUE))
                userHeaderValue = outHeaderVALUE.FirstOrDefault();


            if (userHeaderValue == myHeaderValue)
                return true;
            else
                return false;
        }



        [HttpGet]
        [Route("api/math/Add/{a}/{b}")]
        public HttpResponseMessage Add(int a, int b)
        {
            if (!IsAuthorizedAccess(Request, new KeyValuePair<string, string>("SecretKey", "SecretPassword")))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);

            HttpResponseMessage response;

            try
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(Convert.ToString(a + b));
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
            }

            return response;
        }



        [HttpGet]
        [Route("api/math/Multiply/{a}/{b}")]
        public HttpResponseMessage Multiply(int a, int b)
        {
            if (!IsAuthorizedAccess(Request, new KeyValuePair<string, string>("SecretKey", "SecretPassword")))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);



            HttpResponseMessage response;

            try
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(Convert.ToString(a * b));
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
            }

            return response;
        }



        [HttpGet]
        [Route("api/math/Divide/{a}/{b}")]
        public HttpResponseMessage Divide(int a, int b)
        {
            if (!IsAuthorizedAccess(Request, new KeyValuePair<string, string>("SecretKey", "SecretPassword")))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);



            HttpResponseMessage response;

            try
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(Convert.ToString(a / b));
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
            }

            return response;
        }


    }
}
