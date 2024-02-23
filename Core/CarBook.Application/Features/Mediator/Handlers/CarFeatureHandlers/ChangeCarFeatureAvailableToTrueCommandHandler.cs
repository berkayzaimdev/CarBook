﻿using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class ChangeCarFeatureAvailableToTrueCommandHandler : IRequestHandler<ChangeCarFeatureAvailableToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public ChangeCarFeatureAvailableToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeCarFeatureAvailableToTrueCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeCarFeatureAvailableToTrueAsync(request.Id);
        }
    }
}
