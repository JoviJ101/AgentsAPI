using AgentsApi.Data;
using AgentsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CarUpdateService
{
    private readonly ApplicationDbContext _context;

    public CarUpdateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task UpdateOrAddCarAsync(Car apiCar)
    {
        
        apiCar.ServiceHistory = apiCar.ServiceHistory ?? "No service history available";

        var existingCar = await _context.Cars.FindAsync(apiCar.Id);

        if (existingCar != null)
        {
            
            _context.Entry(existingCar).CurrentValues.SetValues(apiCar);
        }
        else
        {
            
            await _context.Cars.AddAsync(apiCar);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<Car>> GetAllCarsAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
