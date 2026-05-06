using BookCafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.BusinessExceptions
{
    public sealed class BusinessExceptions : Exception
    {
        public BusinessErrorCode Error;
        public BusinessExceptions(string message , BusinessErrorCode error): base(message) 
        {
          Error = error;
        }
    }
}
