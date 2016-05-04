using System;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class ApiException : Exception
    { 
        public ApiResponse Response { get; set; }

        public ApiException(ApiResponse response, string message)
            : base(message)
        {
            Response = response;
        }
    }
}
