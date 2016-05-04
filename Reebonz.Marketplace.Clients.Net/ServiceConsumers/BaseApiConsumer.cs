using System.Net;
using Newtonsoft.Json;
using Reebonz.Marketplace.Clients.Net.Entities;
using RestSharp;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public abstract class BaseApiConsumer
    {
        protected bool ThrowOnErrorStatus { get; }
        protected RestClient Client { get; set; }

        protected BaseApiConsumer(RestClient client, bool throwOnErrorStatus)
        {
            Client = client;
            ThrowOnErrorStatus = throwOnErrorStatus;
        }

        protected ApiResponse<T> HandleResponse<T>(IRestResponse response, bool usesApiResponse = true)
        {
            var res = new ApiResponse<T>
            {
                StatusCode = response.StatusCode
            };

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    if(usesApiResponse)
                    {
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
                        res.Resource = apiResponse.Resource;
                        res.ResourceId = apiResponse.ResourceId;
                        res.Warnings = apiResponse.Warnings;
                    }
                    else
                    {
                        res.Resource = JsonConvert.DeserializeObject<T>(response.Content);
                    }
                    break;
                case HttpStatusCode.NoContent:
                    break;
                case HttpStatusCode.NotFound:
                case HttpStatusCode.BadRequest:
                    {
                        var er = JsonConvert.DeserializeObject<ApiErrorResponse>(response.Content);
                        res.Errors = er.Errors;
                        res.Warnings = er.Warnings;
                    }
                    break;
            }

            if(ThrowOnErrorStatus)
                throw new ApiException(res, "Error response from Marketplace API, see Response property for details");

            return res;
        }
    }
}
