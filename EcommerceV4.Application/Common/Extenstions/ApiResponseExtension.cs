using EcommerceV4.Application.Common.Abstractions.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceV4.Application.Common.Extenstions
{
    public static class ApiResponseExtension
    {
        public static IActionResult ToActionResult(this ApiResponse response)
        {
            if(response.StatusCode == StatusCodes.Status200OK)
            {
                return new OkObjectResult(response);
            }
            
            if(response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return new BadRequestObjectResult(response);
            }    

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }    
    }
}
