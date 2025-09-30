using Microsoft.AspNetCore.Http;

namespace EcommerceV4.Application.Common.Abstractions.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; } 
        public string Message { get; set; } = "Successfully!";
        public IEnumerable<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
            Message = success ? "Successfully" : "Failed";
        }

        public ApiResponse(bool success, int statusCode, string message) : this(success, statusCode) 
        {
            Message = message;
        }

        public ApiResponse(bool success, int statusCode, IEnumerable<string> errors) : this(success, statusCode)
        {
            Errors = errors;
        }

        public ApiResponse(bool success, int statusCode, string message, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
            Errors = errors;
            StatusCode = statusCode;
        }
  


        public static ApiResponse Ok()
        {
            return new ApiResponse(true, StatusCodes.Status200OK);
        }

        public static ApiResponse Ok(string message)
        {
            return new ApiResponse(true, StatusCodes.Status200OK, message);
        }

        public static ApiResponse BadRequest()
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest);
        }

        public static ApiResponse BadRequest(List<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest, errors);
        }

        public static ApiResponse Unauthorized()
        {
            return new ApiResponse(false, StatusCodes.Status401Unauthorized);
        }

        public static ApiResponse Unauthorized(IEnumerable<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status401Unauthorized, errors);
        }

        public static ApiResponse Unauthorized(string message)
        {
            return new ApiResponse(false, StatusCodes.Status401Unauthorized, message);
        }

        public static ApiResponse NotFound()
        {
            return new ApiResponse(false, StatusCodes.Status404NotFound);
        }

        public static ApiResponse NotFound(IEnumerable<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status404NotFound, errors);
        }

        public static ApiResponse Fail()
        {
            return new ApiResponse(false, StatusCodes.Status500InternalServerError);
        }

        public static ApiResponse Fail(List<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status500InternalServerError, errors);
        }

        public static ApiResponse FormatException()
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest);
        }

        public static ApiResponse FormatException(IEnumerable<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest, errors);
        }

        public static ApiResponse InvalidOperationException()
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest);
        }

        public static ApiResponse InvalidOperationException(List<string> errors)
        {
            return new ApiResponse(false, StatusCodes.Status400BadRequest, errors);
        }
    }
}
