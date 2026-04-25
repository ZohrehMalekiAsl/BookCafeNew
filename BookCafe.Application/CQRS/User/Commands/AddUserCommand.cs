using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BookCafe.Application.CQRS.User.Commands
{
    public class AddUserCommand: IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
