using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCarsAsync()
        {
            return await _context.CarPricings
                .Include(x => x.Car)            // Foreign Key ile Car verisini çek
                .ThenInclude(y => y.Brand)      // Car'daki Foreign Key ile Brand verisini çek
                .Include(z => z.Pricing)        // Foreign Key ile Pricing verisini çek
                .Where(x => x.PricingID == 3)   // Sadece günlük fiyatlandırmaya ait verileri çektik
                .ToListAsync();
        }
    }
}
