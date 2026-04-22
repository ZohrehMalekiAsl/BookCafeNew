using BookCafe.Application.Interfaces.Infra;
using BookCafe.Domain.Entities;
using BookCafe.Domain.Repositories;
using BookCafe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : GenericRepository<User>(dbContext), IUserRepository
    {
        public  async Task<User> GetUser(string username)
        {
            return await dbContext.User.FirstOrDefaultAsync(s=>s.UserName==username);
        }
        public  async Task<bool> AddUser(User user)
        {
            dbContext.User.Add(user);
            var result= await unitOfWork.AysncSave();
            if (result == null)
                return false;
            return true;
        }

        public async Task<bool> SaveRefreshToken(User user)
        {
            dbContext.User.Update(user);
            var result= await unitOfWork.AysncSave();
            if(result==null)
                return false;
            return true;
        }
    }
}
