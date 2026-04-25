using BookCafe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCafe.Infrastructure.Config
{
    public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(x => x.Token).HasMaxLength(450);
            builder.HasOne(s=>s.user)
                .WithMany(b=>b.RefreshTokens)
                .HasForeignKey(a => a.UserId);
        }
    }
}
