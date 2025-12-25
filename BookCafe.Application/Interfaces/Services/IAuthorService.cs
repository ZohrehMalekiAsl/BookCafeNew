using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Application.CQRS.Authors.Queries;
using BookCafe.Application.Dtos.Authors;
using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAuthorsBySpecificatin(GetAuthorQuery authorQuery);
        Task<Guid> AddAuthor(AddAuthorCommand author);
        Task<bool> UpdateAuthor(UpdateAuthorCommand author);
    }
}
