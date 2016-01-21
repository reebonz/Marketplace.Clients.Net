using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Reebonz.Marketplace.Clients.Net.Config;
using Reebonz.Marketplace.Clients.Net.Models;
using Reebonz.Marketplace.Clients.Net.ValueObjects;

namespace Reebonz.Marketplace.Clients.Net.Helpers
{

    // TODO Vu.Nguyen: have Nick review
    public static class RestApiHelper
    {
        public static string BaseApiAddress = ApiConfig.HostName;

        // TODO Vu.Nguyen: have Nick review
        public static async Task<T> InvokeApiAsync<T>(string url, HttpMethod httpMethod, ApiHeader apiHeader = null, object body = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseApiAddress);
                var requestMessage = new HttpRequestMessage(httpMethod, url);

                if (apiHeader != null)
                {
                    foreach (var header in apiHeader.GetHeaders())
                    {
                        requestMessage.Headers.Add(header.Key, header.Value);
                    }
                }

                if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put || httpMethod == HttpMethod.Delete)
                {
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body));
                    requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType.Json.GetMediaType());
                }

                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    ProcessHttpErrorResponse(response);
                }

                var deserializedContent = await response.Content.ReadAsAsync<T>();
                return deserializedContent;
            }
        }

        public static T InvokeApi<T>(string url, HttpMethod httpMethod, ApiHeader apiHeader = null, object body = null)
        {
            return InvokeApiAsync<T>(url, httpMethod, apiHeader, body).Result;
        }

        // TODO Vu.Nguyen: have Nick review
        private static void ProcessHttpErrorResponse(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            // Process error for Post and Put api method.
            var apiErrorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(content);
            if (apiErrorResponse.Errors != null || apiErrorResponse.Warnings != null)
            {
                var message = string.Empty;
                if (apiErrorResponse.Errors != null)
                {
                    message += string.Join(Environment.NewLine, apiErrorResponse.Errors.Select(e => e.Message));
                }
                if (apiErrorResponse.Warnings != null)
                {
                    message += string.Join(Environment.NewLine, apiErrorResponse.Warnings.Select(w => w.Message));

                }
                throw new Exception(message);
            }

            // Process error for Get api method.
            var httpError = JsonConvert.DeserializeObject<HttpError>(content);
            if (httpError != null)
            {
                throw new Exception(httpError["ExceptionMessage"].ToString());
            }

            response.EnsureSuccessStatusCode();
        }
    }
}