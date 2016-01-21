using Reebonz.Marketplace.Clients.Net.Models;

namespace Reebonz.Marketplace.Clients.Net.ServiceConsumers
{
    public abstract class BaseApiConsumer
    {
        protected ApiHeader ApiHeader { get; set; }
        public abstract string ApiControllerUrl { get; set; }

        protected BaseApiConsumer(string token)
        {
            ApiHeader = new ApiHeader(token);
        }
    }
}
