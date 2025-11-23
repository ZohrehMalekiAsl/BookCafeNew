using BookCafe.Application.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Contracts.Services
{
    public interface IAuthorService
    {
        Task<Guid> AddAuthorAsynce(CreateAuthorDto authorDto);
        Task<bool> UpdateAuthorAsynce(Guid authorId, UpdateAuthorDto authorDto);
        //Task<List<AuthorDto>> GetAuthorAsync();
    }
}
