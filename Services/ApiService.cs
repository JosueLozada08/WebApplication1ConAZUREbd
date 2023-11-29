using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ApiService : IApiService
    {
        private static string _baseUrl;

        public ApiService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();   
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<List<Producto>> GetProductos()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("/api/Producto");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
            return productos;
        }

        public async Task<Producto> GetProducto(int id)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"/api/Producto/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(content);
                return producto;
            }
            return null;

        }

        public async Task<bool> AddProducto(Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonString = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Producto", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProducto(int id, Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonString = JsonConvert.SerializeObject(producto);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"/api/Producto/{id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"/api/Producto/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
