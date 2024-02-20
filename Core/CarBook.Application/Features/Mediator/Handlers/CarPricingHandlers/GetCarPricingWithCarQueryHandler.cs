using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCarsAsync();
            return values.Select(value => new GetCarPricingWithCarQueryResult 
            {
                CarID = value.CarID,
                CarPricingId = value.CarPricingID,
                Model = value.Car.Model,
                Brand = value.Car.Brand.Name,
                Amount = value.Amount,
                CoverImageUrl = value.Car.CoverImageUrl
            }).ToList();
        }
    }
}
