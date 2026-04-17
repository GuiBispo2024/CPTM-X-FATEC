using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
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
                .HasConversion<int>() //Oracle (1/0)
                .IsRequired();
        });

        modelBuilder.HasSequence<int>("SEQ_USERS");
    }
}
