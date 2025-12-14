using BookCafe.Application.Dtos.Authors;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.CQRS.Authors.Queries
{
    public class GetAuthorQueryHandler: IRequestHandler<GetAuthorQuery, List<AuthorDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<List<AuthorDto>> Handle(GetAuthorQuery authorQuery, CancellationToken cancellationToken)
        {
            return await _authorService.GetAuthorsBySpecificatin(authorQuery);
        }
    }
}
