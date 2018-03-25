using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using ApplicationCore.Entities;

namespace AStores.WebAPIClient.Services
{
    public class ProductClient
    {
        static HttpClient _client;

        public ProductClient(HttpClient client)
        {
            _client = client;
        }
        static async Task<Uri> CreateProductAsync(Product product)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }

        static async Task<Product> UpdateProductAsync(Product product)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(
                $"api/products/{product.F_Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<Product>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }


    }
}
