using AgentsApi.Data;
using AgentsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class CarService
{
    private readonly ApiService _apiService;
    private readonly CarUpdateService _carUpdateService;
    private readonly IMemoryCache _cache;
    private const string CarCacheKey = "CarDataCache";
    private readonly TimeSpan CacheDuration = TimeSpan.FromHours(1); 

    public CarService(ApiService apiService, CarUpdateService carUpdateService, IMemoryCache cache)
    {
        _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        _carUpdateService = carUpdateService ?? throw new ArgumentNullException(nameof(carUpdateService));
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task FetchAndStoreCarsAsync()
    {
        var cars = await _apiService.FetchCarsAsync();

        if (cars != null)
        {
            // Cache data
            _cache.Set(CarCacheKey, cars, CacheDuration);

            foreach (var car in cars)
            {
                await _carUpdateService.UpdateOrAddCarAsync(car);
            }

            await _carUpdateService.SaveChangesAsync();
        }
    }

    public async Task<List<Car>> GetCarsFromCacheOrDatabaseAsync()
    {
        // Try to get the cars from the cache
        if (_cache.TryGetValue(CarCacheKey, out List<Car> cachedCars))
        {
            return cachedCars;
        }

        // If not in cache, get from the database
        var carsFromDb = await _carUpdateService.GetAllCarsAsync();

        // Cache the data from the database
        _cache.Set(CarCacheKey, carsFromDb, CacheDuration);

        return carsFromDb;
    }
}