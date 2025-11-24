using BookCafe.Application.Interfaces;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using MediatR;


namespace BookCafe.Application.CQRS.Authors.Commands
{
    public class UpdateAuthorCommandHandler(IAuthorRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand, bool>
    {
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Nationality = request.Nationality
            };
            repository.Update(author);
            var result = await unitOfWork.AysncSave();

            if (result != null)
                return true;
            return false;
        }
    }
}
