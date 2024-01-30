using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Core.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(value => new GetContactQueryResult 
            {
                ContactID = value.ContactID,
                Name = value.Name,
                Email = value.Email,
                Subject = value.Subject,
                Message = value.Message,
                SendDate = value.SendDate
            }).ToList();
        }
    }
}
