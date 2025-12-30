using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> GetUserByUsername(string username)
        {
            return await _repository.GetUser(username);
        }

        public async Task<bool> SaveRefreshToken(User user)
        {
            return await _repository.SaveRefreshToken(user);
        }

        public Task<bool> ValidatePassword(User user, string password)
        {
            if (user.PasswordHash != password) 
               { return Task.FromResult(false); };
            return Task.FromResult(true);
        }
    }
}
