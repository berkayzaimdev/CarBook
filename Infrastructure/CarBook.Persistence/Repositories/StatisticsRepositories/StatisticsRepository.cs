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
            //Select Top(1) BlogId,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc 
            var values = await _context.Comments.GroupBy(x => x.BlogID).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string blogName = await _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefaultAsync();
            return blogName;
        }

        public async Task<string> GetBrandNameByMaxCarAsync()
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = await _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefaultAsync();
            string brandName = await _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
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
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = await _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefaultAsync();
            decimal amount = await _context.CarPricings.Where(y => y.PricingID == pricingID).MaxAsync(x => x.Amount);
            int carId = await _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefaultAsync();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMinAsync()
        {
            int pricingID = await _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefaultAsync();
            decimal amount = await _context.CarPricings.Where(y => y.PricingID == pricingID).MinAsync(x => x.Amount);
            int carId = await _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefaultAsync();
            string brandModel = await _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
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
