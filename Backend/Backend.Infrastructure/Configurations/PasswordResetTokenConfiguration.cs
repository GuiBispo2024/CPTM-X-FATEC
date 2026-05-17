using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PasswordResetTokenConfiguration
    : IEntityTypeConfiguration<PasswordResetToken>
{
    public void Configure(
        EntityTypeBuilder<PasswordResetToken> entity)
    {
        entity.ToTable("PASSWORD_RESET_TOKENS");

        entity.HasKey(t => t.Id);

        entity.Property(t => t.Id)
            .HasColumnName("ID");

        entity.Property(t => t.UserId)
            .HasColumnName("USER_ID");

        entity.Property(t => t.Token)
            .HasColumnName("TOKEN");

        entity.Property(t => t.ExpiresAt)
            .HasColumnName("EXPIRES_AT");

        entity.Property(t => t.Used)
            .HasColumnName("USED")
            .HasConversion<int>();
    }
}