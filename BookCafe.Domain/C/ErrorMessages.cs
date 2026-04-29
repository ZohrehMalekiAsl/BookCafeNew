using BookCafe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Domain.BusinessExceptions
{
    public static class ErrorMessages
    {
        private static readonly Dictionary<BusinessErrorCode, string> _messages = new()
        {
            { BusinessErrorCode.AuthorNotFound, "Author Not Found"},
            { BusinessErrorCode.UserNotFound, "UserNotFound"},
            { BusinessErrorCode.UserDeactivated, "UserDeactivated"},
            { BusinessErrorCode.BookNotFound, "BookNotFound"  },
            { BusinessErrorCode.UserAlreadyExists, "User Already Exists"}
    
        };
        public static bool GetMessage(BusinessErrorCode code, out string message) =>
        _messages.TryGetValue(code, out message);
    }
}
