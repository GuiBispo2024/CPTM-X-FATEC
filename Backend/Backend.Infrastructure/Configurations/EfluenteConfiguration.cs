using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EfluenteConfiguration
    : IEntityTypeConfiguration<Efluente>
{
    public void Configure(
        EntityTypeBuilder<Efluente> builder)
    {
        builder.ToTable("PT_EFLUENTE");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.HasIndex(e => e.SyncId)
            .IsUnique();

        builder.Property(e => e.SyncId)
            .HasColumnName("SYNC_ID");

        builder.Property(e => e.SyncStatus)
            .HasColumnName("SYNC_STATUS")
            .HasConversion<int>();

        builder.Property(e => e.NomeContratada)
            .HasColumnName("NOME_CONTRATADA")
            .HasMaxLength(255);

        builder.Property(e => e.NumeroContrato)
            .HasColumnName("NUMERO_CONTRATO")
            .HasMaxLength(100);

        builder.Property(e => e.SiglaDepartamentoMeioAmbiente)
            .HasColumnName("SIGLA_DEPTO_MA")
            .HasMaxLength(100);

        builder.Property(e => e.AreaGestoraCptm)
            .HasColumnName("AREA_GESTORA_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.DiretoriaCptm)
            .HasColumnName("DIRETORIA_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.ProgramaAmbiental)
            .HasColumnName("PROGRAMA_AMBIENTAL")
            .HasMaxLength(255);

        builder.Property(e => e.NaturezaPga)
            .HasColumnName("NATUREZA_PGA")
            .HasMaxLength(255);

        builder.Property(e => e.Municipio)
            .HasColumnName("MUNICIPIO")
            .HasMaxLength(255);

        builder.Property(e => e.LinhaCptm)
            .HasColumnName("LINHA_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.ViaCptm)
            .HasColumnName("VIA_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.TrechoSentido)
            .HasColumnName("TRECHO_SENTIDO")
            .HasMaxLength(255);

        builder.Property(e => e.EstacaoCptm)
            .HasColumnName("ESTACAO_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.Endereco)
            .HasColumnName("ENDERECO")
            .HasMaxLength(500);

        builder.Property(e => e.CoordenadaGeografica)
            .HasColumnName("COORDENADA_GEO")
            .HasMaxLength(255);

        builder.Property(e => e.TipoAtividade)
            .HasColumnName("TIPO_ATIVIDADE")
            .HasMaxLength(255);

        builder.Property(e => e.TipoDra)
            .HasColumnName("TIPO_DRA")
            .HasMaxLength(255);

        builder.Property(e => e.TipoAtividadeCptm)
            .HasColumnName("TIPO_ATIVIDADE_CPTM")
            .HasMaxLength(255);

        builder.Property(e => e.NomeLocalAtividade)
            .HasColumnName("NM_LOCAL_ATIVIDADE")
            .HasMaxLength(255);

        builder.Property(e => e.OrigemEfluente)
            .HasColumnName("ORIGEM_EFLUENTE")
            .HasMaxLength(255);

        builder.Property(e => e.FonteGeradora)
            .HasColumnName("FONTE_GERADORA")
            .HasMaxLength(255);

        builder.Property(e => e.TipoDestinacao)
            .HasColumnName("TIPO_DESTINACAO")
            .HasMaxLength(255);

        builder.Property(e => e.TipoVeiculo)
            .HasColumnName("TIPO_VEICULO")
            .HasMaxLength(255);

        builder.Property(e => e.StatusDesvioAmbiental)
            .HasColumnName("STATUS_DESVIO")
            .HasMaxLength(255);

        builder.Property(e => e.StatusRegistroBd)
            .HasColumnName("STATUS_REGISTRO_BD")
            .HasMaxLength(255);

        builder.Property(e => e.Observacao)
            .HasColumnName("OBSERVACAO")
            .HasMaxLength(300);

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("UPDATED_AT");

        builder.Property(e => e.IsDeleted)
            .HasColumnName("IS_DELETED")
            .HasConversion(
                v => v ? 1 : 0,
                v => v == 1
            );
    }
}