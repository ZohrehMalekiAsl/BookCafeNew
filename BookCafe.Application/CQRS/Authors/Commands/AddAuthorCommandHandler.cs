using BookCafe.Domain.Repositories;
using BookCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.CQRS.Authors.Commands
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Guid>
    {
        private readonly IRepository _repository;

        public AddAuthorCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                Nationality = request.Nationality,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            await _repository.AddAsync(author);
            return author.Id;

        }
    }
}
