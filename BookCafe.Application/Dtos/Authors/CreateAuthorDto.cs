using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Application.Dtos.Author
{
    public class CreateAuthorDto
    {
        public string FirstName1 { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Nationality { get; set; }
    }
}
