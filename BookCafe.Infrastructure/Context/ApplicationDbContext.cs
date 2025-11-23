using BookCafe.Domain.Entities;
using BookCafe.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookCafe.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>();
            builder.Entity<Customer>();
            builder.Entity<Author>();
            builder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);

        }        
    }
}
