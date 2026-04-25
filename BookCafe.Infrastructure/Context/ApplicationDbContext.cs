using BookCafe.Domain.Entities;
using BookCafe.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCafe.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>();
            builder.Entity<Customer>();
            builder.Entity<Author>();
            builder.Entity<User>().HasIndex(u => u.UserName).IsUnique().HasFilter("[IsActive]=1"); 
            builder.Entity<RefreshToken>().HasIndex(u => u.Token).IsUnique(); 
            builder.ApplyConfigurationsFromAssembly(typeof(BookConfig).Assembly);
        }
    }
}
