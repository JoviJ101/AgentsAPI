using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AgentsApi.Models;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        var username = configuration["ApiSettings:Username"];
        var password = configuration["ApiSettings:Password"];
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
    }

    public async Task<List<Car>> FetchCarsAsync()
    {
        var response = await _httpClient.GetAsync("");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var cars = JsonSerializer.Deserialize<List<Car>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return cars;
    }
}
