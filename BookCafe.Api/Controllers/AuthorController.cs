using BookCafe.Application.CQRS.Authors.Commands;
using BookCafe.Application.CQRS.Authors.Queries;
using BookCafe.Application.Dtos.Author;
using BookCafe.Application.Dtos.Authors;
using BookCafe.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddAuthor")]
        public async Task<IActionResult> AddAuthor(CreateAuthorDto author)
        {
            var command = new AddAuthorCommand
            {
                BirthDate = author.BirthDate,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality
            };
            var result = await _mediator.Send(command);
            if (result != Guid.Empty)
            {
                return Ok(new { AuthorId = result });
            }
            else
            {
                return BadRequest("Author creation failed.");
            }
        }
        [HttpPut(Name = "AddAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto author)
        {
            var command = new UpdateAuthorCommand
            {
                BirthDate = author.BirthDate,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality
            };
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Author creation failed.");
            }
        }

        [HttpGet(Name ="GetAuthor")]
        public async Task<IActionResult> GetAuthor([FromQuery] AuthorDto author)
        {
            var query = new GetAuthorQuery
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality
            };
            var result = _mediator.Send(query);
            return Ok(result.Result);
        }
    }
}
