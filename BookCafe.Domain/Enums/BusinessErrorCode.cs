using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.Enums
{
    public enum BusinessErrorCode 
    {
        UserAlreadyExists = 1001,
        UserDeactivated = 1002,
        UserNotFound = 1003,
        BookNotFound = 2001,
        AuthorNotFound = 3001,
        Unknown=9999

    }
}
