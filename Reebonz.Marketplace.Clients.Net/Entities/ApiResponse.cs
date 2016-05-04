
using System.Net;

namespace Reebonz.Marketplace.Clients.Net.Entities
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public ApiError[] Warnings { get; set; }
        public ApiError[] Errors { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public string ResourceId { get; set; }
        public T Resource { get; set; }
    }

    public class ApiErrorResponse
    {
        public ApiError[] Warnings { get; set; }
        public ApiError[] Errors { get; set; }
    }

    public class ApiError
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApiError()
        { }

        public ApiError(string code, string field, string message, object data = null)
        {
            Code = code;
            Field = field;
            Message = message;
            Data = data;
        }
    }
}