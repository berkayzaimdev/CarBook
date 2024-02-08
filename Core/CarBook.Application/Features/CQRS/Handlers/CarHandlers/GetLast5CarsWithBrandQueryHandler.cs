using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast5CarsWithBrandQueryResult>> HandleAsync()
        {
            var values = await _repository.GetLast5CarsListWithBrandsAsync();
            return values.Select(value => new GetLast5CarsWithBrandQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
                BrandName = value.Brand.Name,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                BigImageUrl = value.BigImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel
            }).ToList();
        }
    }
}
