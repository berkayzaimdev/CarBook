using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Core.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IAppUserRepository _repository;

		public GetCheckAppUserQueryHandler(IAppUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var value = new GetCheckAppUserQueryResult();
			var user = await _repository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
			if(user == null)
			{
				value.IsExist = false;
			}
			else
			{
				value.IsExist = true;
				value.Username = user.Username;
				value.Role = user.AppRole.AppRoleName;
				value.AppUserID = user.AppUserID;
			}
			return value;
		}
	}
}
