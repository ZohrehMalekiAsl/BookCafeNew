using BookCafe.Domain.Entities;

namespace BookCafe.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string  username);
        void Add(User  user);
        void Update(User user);
    }
}
