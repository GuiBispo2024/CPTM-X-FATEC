using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EfluenteConfiguration
    : IEntityTypeConfiguration<Efluente>
{
    public void Configure(
        EntityTypeBuilder<Efluente> builder)
    {
        builder.ToTable("PT_EFLUENTE");

        // PK
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        // Institucional
        builder.Property(x => x.NomeContratada)
            .HasColumnName("TX_NOME_CONTRATADA")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.NumeroContrato)
            .HasColumnName("TX_NUMERO_CONTRATO")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ProgramaAmbiental)
            .HasColumnName("TX_PROGRAMA_AMBIENTAL")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Natureza)
            .HasColumnName("TX_NATUREZA")
            .HasMaxLength(100)
            .IsRequired();

        // Caracterização
        builder.Property(x => x.LinhaCptm)
            .HasColumnName("TX_LINHA_CPTM")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ViaCptm)
            .HasColumnName("TX_VIA_CPTM")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Municipio)
            .HasColumnName("TX_MUNICIPIO")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Endereco)
            .HasColumnName("TX_ENDERECO")
            .HasMaxLength(300);

        builder.Property(x => x.CoordenadaGeografica)
            .HasColumnName("TX_COORDENADA_GEOGRAFICA")
            .HasMaxLength(200);

        builder.Property(x => x.TipoEfluente)
            .HasColumnName("TX_TIPO_EFLUENTE")
            .HasMaxLength(100);

        builder.Property(x => x.StatusDesvioAmbiental)
            .HasColumnName("TX_STATUS_DESVIO_AMBIENTAL")
            .HasMaxLength(100);

        builder.Property(x => x.Observacao)
            .HasColumnName("TX_OBSERVACAO")
            .HasMaxLength(2000);

        // Controle
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DT_DATA_CADASTRO")
            .IsRequired();
    }
}