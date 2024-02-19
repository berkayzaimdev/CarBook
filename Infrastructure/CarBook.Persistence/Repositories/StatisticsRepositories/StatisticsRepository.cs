using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<string> GetBlogTitleByMaxBlogCommentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetBrandNameByMaxCarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAuthorCountAsync()
        {
            var value = await _context.Authors.CountAsync();
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForDailyAsync()
        {
            int id = await _context.Pricings.Where(p => p.Name == "Günlük").Select(p => p.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForMonthlyAsync()
        {
            int id = await _context.Pricings.Where(p => p.Name == "Aylık").Select(p => p.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForWeeklyAsync()
        {
            int id = await _context.Pricings.Where(p => p.Name == "Haftalık").Select(p => p.PricingID).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.PricingID == id).AverageAsync(x => x.Amount);
            return value;
        }

        public async Task<int> GetBlogCountAsync()
        {
            var value = await _context.Blogs.CountAsync();
            return value;
        }

        public async Task<int> GetBrandCountAsync()
        {
            var value = await _context.Brands.CountAsync();
            return value;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMaxAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMinAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCarCountAsync()
        {
            var value = await _context.Cars.CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelElectricAsync()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Elektrikli").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByFuelGasolineOrDieselAsync()
        {
            var value = await _context.Cars.Where(x => x.Fuel == "Benzinli" || x.Fuel == "Dizel").CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByKmSmallerThan1000Async()
        {
            var value = await _context.Cars.Where(x => x.Km < 1000).CountAsync();
            return value;
        }

        public async Task<int> GetCarCountByTransmissionIsAutoAsync()
        {
            var value = await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
            return value;
        }

        public async Task<int> GetLocationCountAsync()
        {
            var value = await _context.Locations.CountAsync();
            return value;
        }
    }
}
