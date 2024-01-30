using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Core.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
            value.Name = command.Name;
            value.Email = command.Email;
            value.Subject = command.Subject;
            value.Message = command.Message;
            value.SendDate = command.SendDate;
            await _repository.UpdateAsync(value);
        }
    }
}
