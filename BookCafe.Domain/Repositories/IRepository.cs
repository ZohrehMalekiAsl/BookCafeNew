using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Repositories
{
    public interface IRepository
    {
        Task<Guid> AddAsync<T>(T Entity);
        Task<bool> UpdateAsync<T>(T Entity);
    }
}
