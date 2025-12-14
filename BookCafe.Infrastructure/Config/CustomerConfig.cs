using BookCafe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCafe.Infrastructure.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.CellPhone).HasMaxLength(11);
            builder.Property(x => x.Email).HasMaxLength(254);
            builder.Property(x => x.NationalId).IsUnicode(true);

            builder.OwnsOne(x => x.Address, address =>
                {
                    address.Property(x => x.City).HasMaxLength(100);
                    address.Property(x => x.Street).HasMaxLength(500);
                    address.Property(x => x.Plaque).HasMaxLength(100);
                });
        }
    }
}
