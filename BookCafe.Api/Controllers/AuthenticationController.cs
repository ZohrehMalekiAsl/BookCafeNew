using BookCafe.Application.CQRS.Token.Commands;
using BookCafe.Application.Dtos.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetAccessToken")]
        public async Task<IActionResult> GetAccessToken(LoginRequestDto requestDto)
        {
            var command = new GenerateTokenCommand
            {
                Password = requestDto.Password,
                UserName = requestDto.UserName
            };
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
    }
}
