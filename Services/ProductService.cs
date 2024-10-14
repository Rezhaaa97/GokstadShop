
using System.Net.Http.Json;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _http.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
    }
}
