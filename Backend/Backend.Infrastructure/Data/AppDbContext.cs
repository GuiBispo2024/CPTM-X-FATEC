using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Efluente> Efluentes { get; set; }
    public DbSet<Municipio> Municipios { get; set; }
    public DbSet<FotoEfluente> Fotos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Mapeamento de Usuários
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            entity.Property(u => u.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
            entity.Property(u => u.Email).HasColumnName("EMAIL").HasMaxLength(150).IsRequired();
            entity.Property(u => u.PasswordHash).HasColumnName("PASSWORD_HASH").HasMaxLength(255).IsRequired();
            entity.Property(u => u.IsAdmin).HasColumnName("IS_ADMIN").HasConversion(v => v ? 1 : 0, v => v == 1);
        });

        // 2. Mapeamento de Município
        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.ToTable("DOMINIO_MUNICIPIO");
            entity.HasKey(m => m.Codigo);
            entity.Property(m => m.Codigo).HasColumnName("PK_CD_MUNICIPIO");
            entity.Property(m => m.Nome).HasColumnName("TX_NM_MUNICIPIO").HasMaxLength(255).IsRequired();
        });

        // 3. Mapeamento de Efluente
        modelBuilder.Entity<Efluente>(entity =>
        {
            entity.ToTable("PT_EFLUENTE");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("PK_CD_MEIO_AMBIENTE_CPTM");
            entity.Property(e => e.NumeroElemento).HasColumnName("TX_NR_ELEMENTO_MONITORAMENTO");
            entity.Property(e => e.NomeElemento).HasColumnName("TX_NM_ELEMENTO_MONITORAMENTO");
            entity.Property(e => e.Latitude).HasColumnName("NR_LAT_GRAU_DECIMAL_WGS84");
            entity.Property(e => e.Longitude).HasColumnName("NR_LONG_GRAU_DECIMAL_WGS84");
            entity.Property(e => e.DataEmissao).HasColumnName("DT_DATA_EMISSAO_FORMULARIO").HasDefaultValueSql("SYSDATE");
            entity.Property(e => e.Status).HasColumnName("TX_STATUS_DO_REGISTRO_NO_BD").HasDefaultValue("ATIVO");
            entity.Property(e => e.MunicipioId).HasColumnName("FK_CD_MUNICIPIO");
            entity.Property(e => e.DetalheLocalizacao).HasColumnName("TX_DETALHE_LOCALIZACAO").HasMaxLength(500);

            entity.HasOne(e => e.Municipio)
                  .WithMany()
                  .HasForeignKey(e => e.MunicipioId)
                  .HasConstraintName("FK_MUNICIPIO_INSPECAO");
        });

        // 4. Mapeamento de Foto
        modelBuilder.Entity<FotoEfluente>(entity =>
        {
            entity.ToTable("RT_EFLUENTE");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).HasColumnName("PK_CD_FOTO_EFLUENTE").ValueGeneratedOnAdd();
            entity.Property(f => f.EfluenteId).HasColumnName("FK_CD_MEIO_AMBIENTE_CPTM");
            entity.Property(f => f.Conteudo).HasColumnName("BL_FOTO_EFLUENTE");
            entity.Property(f => f.Legenda).HasColumnName("TX_LEGENDA_FOTO");
            entity.Property(f => f.DataRegistro).HasColumnName("DT_REGISTRO_FOTO").HasDefaultValueSql("SYSDATE");

            entity.HasOne(f => f.Efluente)
                  .WithMany()
                  .HasForeignKey(f => f.EfluenteId)
                  .HasConstraintName("FK_INSPECAO_FOTO");
        });

        modelBuilder.HasSequence<int>("SEQ_USERS");
    }
}