using BookCafe.Application.Dtos.Authors;
using BookCafe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.CQRS.Authors.Queries
{
    public class GetAuthorQuery: IRequest<List<AuthorDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
    }
}
