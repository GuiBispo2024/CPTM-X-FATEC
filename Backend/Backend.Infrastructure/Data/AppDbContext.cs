using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

    public DbSet<Efluente> Efluentes { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

        modelBuilder.HasSequence<int>("SEQ_USERS");
    }
}