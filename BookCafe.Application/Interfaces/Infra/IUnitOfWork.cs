using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Interfaces.Infra
{
    public interface IUnitOfWork
    {
        Task<int> AysncSave();
    }
}
