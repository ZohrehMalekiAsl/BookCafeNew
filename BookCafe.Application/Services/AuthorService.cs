using AutoMapper;
using BookCafe.Application.CQRS.Authors.Queries;
using BookCafe.Application.Dtos.Authors;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAuthorsBySpecificatin(GetAuthorQuery authorQuery)
        {
            var author = _mapper.Map<Author>(authorQuery);

            var result = await _repository.GetBySpecificationAsync(author);

            if (result == null || !result.Any())
                return new List<AuthorDto>();
            return _mapper.Map<List<AuthorDto>>(result);
        }
    }
}
