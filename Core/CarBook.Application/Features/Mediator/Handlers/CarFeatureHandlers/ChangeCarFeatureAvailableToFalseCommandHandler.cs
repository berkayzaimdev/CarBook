using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class ChangeCarFeatureAvailableToFalseCommandHandler : IRequestHandler<ChangeCarFeatureAvailableToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public ChangeCarFeatureAvailableToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeCarFeatureAvailableToFalseCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeCarFeatureAvailableToFalseAsync(request.Id);
        }
    }
}
