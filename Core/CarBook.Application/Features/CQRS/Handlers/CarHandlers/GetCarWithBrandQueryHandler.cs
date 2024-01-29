using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Core.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> HandleAsync()
        {
            var values = await _repository.GetCarsListWithBrandsAsync();
            return values.Select(value => new GetCarWithBrandQueryResult
            {
                CarID = value.CarID,
                BrandID = value.BrandID,
                BrandName = value.Brand.Name, //Added
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
