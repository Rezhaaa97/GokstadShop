
using System.Net.Http.Json;
using System.Net.NetworkInformation;

public class ProductService
{
    private readonly HttpClient _http;
    private static List<Product> _cachedProducts;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetProducts()
    {
        try
        {
            if(_cachedProducts != null)
            {
                return _cachedProducts;
            }

             _cachedProducts = await _http.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
            
            return _cachedProducts;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            return new List<Product>();
        }
        
    }

    public async Task<Product> GetProductById(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Product>($"https://fakestoreapi.com/products/{id}");    
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            return null;
        }
        
    }
}
