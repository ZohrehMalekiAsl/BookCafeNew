using BookCafe.Application.CQRS.User.Commands;
using BookCafe.Domain.Entities;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IUserService
    {
        Task<bool> AddUser(AddUserCommand user);
        
        Task<User> GetUserByUsername(string username);
        Task<bool> ValidatePassword(User user, string password);
        Task<bool> SaveRefreshToken(User user);

    }
}
