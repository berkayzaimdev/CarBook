using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Core.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler:IRequestHandler<GetFooterAddressQuery,List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetFooterAddressQueryResult
            {
                FooterAddressID = value.FooterAddressID,
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
                Phone = value.Phone
            }).ToList();
        }
    }
}
