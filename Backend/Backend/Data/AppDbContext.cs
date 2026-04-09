using Microsoft.EntityFrameworkCore;
using Backend.Models;

public class AppDbContext : DbContext
{
    public DbSet<Users> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>()
            .ToTable("USERS"); //nome da tabela no Oracle

        modelBuilder.Entity<Users>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Users>()
            .Property(u => u.Id)
            .HasDefaultValueSql("SEQ_USERS.NEXTVAL");

        modelBuilder.Entity<Users>()
            .Property(u => u.Id)
            .HasColumnName("ID");

        modelBuilder.Entity<Users>()
            .Property(u => u.Name)
            .HasColumnName("NAME");

        modelBuilder.Entity<Users>()
            .Property(u => u.Email)
            .HasColumnName("EMAIL");

        modelBuilder.Entity<Users>()
            .Property(u => u.Password)
            .HasColumnName("PASSWORD");
    }
}
