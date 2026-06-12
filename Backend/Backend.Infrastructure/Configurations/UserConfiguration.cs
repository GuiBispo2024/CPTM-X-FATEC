using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> entity)
    {
        entity.ToTable("USERS");

        entity.HasKey(u => u.Id);

        entity.Property(u => u.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        entity.Property(u => u.Name)
            .HasColumnName("NAME")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(u => u.PasswordHash)
            .HasColumnName("PASSWORD_HASH")
            .HasMaxLength(255)
            .IsRequired();

        entity.Property(u => u.IsAdmin)
            .HasColumnName("IS_ADMIN")
            .HasConversion(
                v => v ? 1 : 0,
                v => v == 1
            )
            .IsRequired();
    }
}