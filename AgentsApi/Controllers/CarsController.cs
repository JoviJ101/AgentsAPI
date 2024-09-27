using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly CarService _carService;
    private readonly ILogger<CarController> _logger;

    public CarController(CarService carService, ILogger<CarController> logger)
    {
        _carService = carService;
        _logger = logger;
    }

    [HttpPost("fetch-and-store-cars")]
    public async Task<IActionResult> FetchAndStoreCars()
    {
        try
        {
            _logger.LogInformation("Starting to fetch and store cars.");
            await _carService.FetchAndStoreCarsAsync();
            _logger.LogInformation("Cars fetched and stored successfully.");
            return Ok("Car data fetched and stored successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching and storing cars.");
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("cars")]
    public async Task<IActionResult> GetCars()
    {
        try
        {
            var cars = await _carService.GetCarsFromCacheOrDatabaseAsync();
            if (cars == null || cars.Count == 0)
            {
                return NotFound("No cars found.");
            }
            return Ok(cars);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving cars.");
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
