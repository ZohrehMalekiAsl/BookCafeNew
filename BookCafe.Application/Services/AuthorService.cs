using AutoMapper;
using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Application.CQRS.Authors.Queries;
using BookCafe.Application.Dtos.Authors;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Application.Interfaces.Services;
using BookCafe.Domain;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using MediatR.Wrappers;
using Microsoft.Extensions.Logging;
using System.Reflection.PortableExecutable;

namespace BookCafe.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService<AuthorService> _logger;
        public AuthorService(IAuthorRepository repository, IUnitOfWork unitOfWork, ILogService<AuthorService> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Guid> AddAuthor(AddAuthorCommand request)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                Nationality = request.Nationality,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
     
            _repository.Add(author);
       
            var result = await _unitOfWork.AysncSave();
            var logData = new LogData<AddAuthorCommand,Guid>
            {
                CorrelationId = author.Id.ToString(),
                ElapsedMilliseconds = DateTime.Now.Microsecond,
                RequestInfo = request
            };

            _logger.LogData<AddAuthorCommand,Guid>(LogLevel.Information, logData);
            return author.Id;
        }

        public async Task<List<AuthorDto>> GetAuthorsBySpecificatin(GetAuthorQuery authorQuery)
        {
            //var author = _mapper.Map<Author>(authorQuery);
            var author = new Author
            {
                FirstName = authorQuery.FirstName,
                LastName = authorQuery.LastName
            };

            var result = await _repository.GetBySpecificationAsync(author);
            var authorList = new List<AuthorDto>();
            if (result == null || !result.Any())
                return new List<AuthorDto>();
            {

                foreach (Author a in result.ToList())
                {
                    var authorDto = new AuthorDto();
                    authorDto.FirstName = a.FirstName;
                    authorDto.LastName = a.LastName;
                    authorDto.Nationality = a.Nationality;
                    authorList.Add(authorDto);
                }
                return authorList;
            }


            //return _mapper.Map<List<AuthorDto>>(result);
        }

        public async Task<bool> UpdateAuthor(UpdateAuthorCommand request)
        {
            var author = new Author
            {
                BirthDate = request.BirthDate,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Nationality = request.Nationality,
                Id = request.Id
            };
            _repository.Update(author);
            var result = await _unitOfWork.AysncSave();

            if (result != null)
                return true;
            return false;
        }
    }
}
