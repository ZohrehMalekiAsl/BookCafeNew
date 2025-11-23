using BookCafe.Application.Contracts.Services;
using BookCafe.Application.Dtos.Author;
using BookCafe.Domain.Contracts;
using BookCafe.Domain.Entities;
namespace BookCafe.Infrastructure.Service.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository _repository;

        public AuthorService(IRepository repository)
        {
            _repository = repository;
        }

        //public async Task<List<AuthorDto>> GetAuthorAsync()
        //{
        //    _repository.
        //}

        public async Task<Guid> AddAuthorAsynce(CreateAuthorDto authorDto)
        {

            Author author = new Author();
            author.BirthDate = authorDto.BirthDate;
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;
            author.Nationality = authorDto.Nationality;

            var result= await _repository.AddAsync(author);
            return new Guid();
        }

        public async Task<bool> UpdateAuthorAsynce(Guid authorId, UpdateAuthorDto authorDto)
        {
            return await _repository.UpdateAsync(authorDto);      
        }
    }
}
