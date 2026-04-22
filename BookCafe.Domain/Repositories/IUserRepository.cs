using BookCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string  username);
        Task<bool> AddUser(User  user);
        Task<bool> SaveRefreshToken(User user);
    }
}
