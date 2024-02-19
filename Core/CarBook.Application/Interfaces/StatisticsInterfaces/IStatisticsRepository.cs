using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCountAsync();
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCountAsync();
        Task<int> GetBrandCountAsync();
        Task<decimal> GetAvgRentPriceForDailyAsync();
        Task<decimal> GetAvgRentPriceForWeeklyAsync();
        Task<decimal> GetAvgRentPriceForMonthlyAsync();
        Task<int> GetCarCountByTransmissionIsAutoAsync();
        Task<string> GetBrandNameByMaxCarAsync();
        Task<string> GetBlogTitleByMaxBlogCommentAsync();
        Task<int> GetCarCountByKmSmallerThan1000Async();
        Task<int> GetCarCountByFuelGasolineOrDieselAsync();
        Task<int> GetCarCountByFuelElectricAsync();
        Task<string> GetCarBrandAndModelByRentPriceDailyMaxAsync();
        Task<string> GetCarBrandAndModelByRentPriceDailyMinAsync();
    }
}
