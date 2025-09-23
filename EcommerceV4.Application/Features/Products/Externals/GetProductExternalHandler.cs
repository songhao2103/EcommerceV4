using System.Text.Json;
using EcommerceV4.Application.Common.Interfaces;

namespace EcommerceV4.Application.Features.Products.Externals
{
    public class GetProductExternalHandler : IExternalApi<List<ProductExternal>>
    {
        public async Task<List<ProductExternal>> GetData()
        {
            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync("http://localhost:2103/product/get-products");

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<GetProductExternalResponseDto>(
                                content,
                                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return data?.products ?? new List<ProductExternal>();
                }

                return new List<ProductExternal>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
