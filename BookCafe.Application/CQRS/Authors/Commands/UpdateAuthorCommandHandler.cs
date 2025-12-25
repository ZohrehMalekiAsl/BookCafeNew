using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using MediatR;


namespace BookCafe.Application.CQRS.Authors.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IAuthorService _authorService ;

        public UpdateAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorService.UpdateAuthor(request);
        }
    }
}
