using BookCafe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Nationality).HasMaxLength(100);
            builder.HasMany<Book>();  
        }
    }
}
