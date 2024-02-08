using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllBlogsWithAuthorAsync();
            return values.Select(value => new GetAllBlogsWithAuthorQueryResult
            {
                 BlogID = value.BlogID,
                 AuthorID = value.AuthorID,
                 AuthorName = value.Author.Name,
                 CategoryID = value.CategoryID,
                 //CategoryName = value.Category.Name,
                 Title = value.Title,
                 CoverImageUrl = value.CoverImageUrl,
                 CreatedDate = value.CreatedDate
            }).ToList();
        }
    }
}
