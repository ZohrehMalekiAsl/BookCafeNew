using BookCafe.Application.CQRS.User.Commands;
using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BookCafe.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _hasher;
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, IPasswordHasher<User> hasher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _hasher = hasher;
        }

        public async Task<bool> AddUser(AddUserCommand userCommand)
        {
            var user = new User
            {
                UserName = userCommand.UserName
                //Password = userCommand.Password,
                //Id=1
            };
            user.PasswordHash= HashPassword(user, userCommand.Password).Result;
     
             _repository.Add(user);
            var result =  await _unitOfWork.AysncSave();
            if (result!=null)
                return true;
            return false;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _repository.GetUser(username);
        }

        public async Task<bool> SaveRefreshToken(User user)
        {
           
            _repository.Update(user);
            var result = await _unitOfWork.AysncSave();
            if (result != null)
                return true;
            return false;
        }     
        private Task<string> HashPassword(User user, string password)
        {
            return Task.FromResult(_hasher.HashPassword(user, password));
        }
        public Task<bool> ValidatePassword(User user, string password)
        {
            var result= Task.FromResult(_hasher.VerifyHashedPassword(user, user.PasswordHash, password));
            return Task.FromResult(true);
        }
    }
}
