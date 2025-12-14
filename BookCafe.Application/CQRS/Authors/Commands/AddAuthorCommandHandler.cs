using BookCafe.Domain.Repositories;
using BookCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCafe.Application.Interfaces.Infra;

namespace BookCafe.Application.CQRS.Authors.Commands
{
    public class AddAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<AddAuthorCommand, Guid>
    {

        public async Task<Guid> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                Nationality = request.Nationality,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            repository.Add(author);
            var result= await unitOfWork.AysncSave();
            return author.Id;

        }
    }
}
