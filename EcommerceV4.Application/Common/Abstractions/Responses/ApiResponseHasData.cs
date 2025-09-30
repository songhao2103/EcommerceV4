using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Application.Common.Abstractions.Responses
{
    public class ApiResponseHasData<T> : ApiResponse
    {
        public T? Data { get; set; }
        public ApiResponseHasData(T? data, bool success, int statusCode) : base(success, statusCode) 
        {
            Data = data;
        }
        public ApiResponseHasData(T? data, bool success, int statusCode, string message) : base(success, statusCode, message)
        {
            Data = data;
        }

        public static ApiResponseHasData<T> Ok(T data)
        {
            return new ApiResponseHasData<T>(data, true, StatusCodes.Status200OK);
        }

        public static ApiResponseHasData<T> Ok(T data, string message)
        {
            return new ApiResponseHasData<T>(data, true, StatusCodes.Status200OK, message);
        }
    }
}
