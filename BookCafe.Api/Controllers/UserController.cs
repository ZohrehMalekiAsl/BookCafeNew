using BookCafe.Application.CQRS.User.Commands;
using BookCafe.Application.Dtos.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace BookCafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(LoginRequestDto request)
        {
            var user = new AddUserCommand()
            {
                Password = request.Password,
                UserName = request.UserName,
            };
            var result = await _mediator.Send(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
