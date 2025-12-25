using BookCafe.Domain.Repositories;
using BookCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Interfaces.Services;

namespace BookCafe.Application.CQRS.Authors.Commands
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Guid>
    {
        private readonly IAuthorService _authorService;

        public AddAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<Guid> Handle(AddAuthorCommand author, CancellationToken cancellationToken)
        {
            return await _authorService.AddAuthor(author);
        }
    }
}
