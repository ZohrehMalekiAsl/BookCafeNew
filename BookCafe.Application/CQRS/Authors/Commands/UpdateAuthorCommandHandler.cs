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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IGeneralRepository _repository;

        public UpdateAuthorCommandHandler(IGeneralRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Nationality = request.Nationality
            };
            var result = await _repository.UpdateAsync(author);
            if(result!=null)
                return true;
            return false;
        }
    }
}
