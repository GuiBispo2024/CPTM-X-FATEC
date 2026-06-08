using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EfluenteConfiguration : IEntityTypeConfiguration<Efluente>
{
    public void Configure(EntityTypeBuilder<Efluente> builder)
    {
        builder.ToTable("PT_EFLUENTE");

        // =========================================
        // PRIMARY KEY
        // =========================================

        builder.HasKey(x => x.CodigoMeioAmbienteCptm);

        builder.Property(x => x.CodigoMeioAmbienteCptm)
            .HasColumnName("PK_CD_MEIO_AMBIENTE_CPTM")
            .HasMaxLength(255);

        // =========================================
        // ID 2-3
        // =========================================

        builder.Property(x => x.NumeroElementoMonitoramento)
            .HasColumnName("TX_NR_ELEMENTO_MONITORAMENTO")
            .HasMaxLength(255);

        builder.Property(x => x.NomeElementoMonitoramento)
            .HasColumnName("TX_NM_ELEMENTO_MONITORAMENTO")
            .HasMaxLength(255);

        // =========================================
        // ID 4-6
        // =========================================

        builder.Property(x => x.SiglaDepartamentoMeioAmbiente)
            .HasColumnName("CD_SIGLA_DEPTO_MEIO_AMBIENTE")
            .HasMaxLength(255);

        builder.Property(x => x.StatusDesvioAmbiental)
            .HasColumnName("CD_STATUS_DO_DESVIO_AMBIENTAL")
            .HasMaxLength(255);

        builder.Property(x => x.StatusRegistroBd)
            .HasColumnName("CD_STATUS_DO_REGISTRO_NO_BD")
            .HasMaxLength(255);

        // =========================================
        // ID 7-17
        // =========================================

        builder.Property(x => x.Municipio)
            .HasColumnName("CD_MUNICIPIO")
            .HasMaxLength(255);

        builder.Property(x => x.LinhaCptm)
            .HasColumnName("CD_LINHA_CPTM")
            .HasMaxLength(255);

        builder.Property(x => x.ViaCptm)
            .HasColumnName("CD_VIA_CPTM")
            .HasMaxLength(255);

        builder.Property(x => x.TrechoSentidoCptm)
            .HasColumnName("CD_TRECHO_E_SENTIDO_CPTM")
            .HasMaxLength(255);

        builder.Property(x => x.KmPoste)
            .HasColumnName("TX_KM_POSTE")
            .HasMaxLength(255);

        builder.Property(x => x.EstacaoCptm)
            .HasColumnName("CD_ESTACAO_CPTM")
            .HasMaxLength(255);

        builder.Property(x => x.LatitudeGrauDecimalWgs84)
            .HasColumnName("NR_LAT_GRAU_DECIMAL_WGS84")
            .HasPrecision(12, 8);

        builder.Property(x => x.LongitudeGrauDecimalWgs84)
            .HasColumnName("NR_LONG_GRAU_DECIMAL_WGS84")
            .HasPrecision(12, 8);

        builder.Property(x => x.LatitudeMetrosSirgas2000)
            .HasColumnName("NR_LAT_METROS_SIRGAS2000")
            .HasPrecision(12, 3);

        builder.Property(x => x.LongitudeMetrosSirgas2000)
            .HasColumnName("NR_LONG_METROS_SIRGAS2000")
            .HasPrecision(12, 3);

        builder.Property(x => x.NomeLocalEscopoContratual)
            .HasColumnName("TX_NM_LOCAL_ESCOPO_CONTRATUAL")
            .HasMaxLength(255);

        // =========================================
        // ID 18-23
        // =========================================

        builder.Property(x => x.TipoFormulario)
            .HasColumnName("TX_TIPO_DE_FORMULARIO")
            .HasMaxLength(255);

        builder.Property(x => x.DataEmissaoFormulario)
            .HasColumnName("DT_DATA_EMISSAO_FORMULARIO");

        builder.Property(x => x.NumeroFormulario)
            .HasColumnName("NR_NUMERO_DE_FORMULARIO");

        builder.Property(x => x.AutorPfFormulario)
            .HasColumnName("TX_AUTOR_PF_DO_FORMULARIO")
            .HasMaxLength(255);

        builder.Property(x => x.NaturezaPga)
            .HasColumnName("CD_NATUREZA_DO_PGA")
            .HasMaxLength(255);

        builder.Property(x => x.NomePjExecutora)
            .HasColumnName("TX_NOME_PJ_EXECUTORA")
            .HasMaxLength(255);

        // =========================================
        // ID 24-30
        // =========================================

        builder.Property(x => x.TipoAtividadeListada).HasColumnName("CD_TIPO_ATIVIDADE_LISTADA").HasMaxLength(255);
        builder.Property(x => x.TipoAtividadeNaoListada).HasColumnName("TX_TIPO_ATIVIDADE_N_LISTADA").HasMaxLength(255);
        builder.Property(x => x.TipoDraListado).HasColumnName("CD_TIPO_DRA_LISTADO").HasMaxLength(255);
        builder.Property(x => x.TipoDraNaoListado).HasColumnName("TX_TIPO_DRA_N_LISTADO").HasMaxLength(255);
        builder.Property(x => x.IdDra).HasColumnName("TX_ID_DRA").HasMaxLength(255);
        builder.Property(x => x.ValidadeDra).HasColumnName("DT_VALIDADE_DRA");
        builder.Property(x => x.AnaliseCptmAprovacao).HasColumnName("TX_ANALISE_CPTM_APROVACAO").HasMaxLength(255);

        // =========================================
        // ID 31-44
        // =========================================

        builder.Property(x => x.TipoAtividadeCptm).HasColumnName("CD_TIPO_ATIVIDADE_CPTM").HasMaxLength(255);
        builder.Property(x => x.NomeLocalAtividade).HasColumnName("CD_NM_LOCAL_ATIV").HasMaxLength(255);
        builder.Property(x => x.NomeLocalAtividadeComplemento).HasColumnName("TX_NM_LOCAL_ATIV_COMPLEMENTO").HasMaxLength(255);
        builder.Property(x => x.OrigemEfluente).HasColumnName("CD_ORIGEM_EFLUENTE").HasMaxLength(255);
        builder.Property(x => x.FonteGeradora).HasColumnName("CD_FONTE_GERADORA").HasMaxLength(255);

        builder.Property(x => x.QuantidadeLitros)
            .HasColumnName("NR_QUANTIDADE_L")
            .HasPrecision(16, 8);

        builder.Property(x => x.TipoDestinacao).HasColumnName("CD_TIPO_DESTINACAO").HasMaxLength(255);
        builder.Property(x => x.TipoVeiculo).HasColumnName("CD_TIPO_VEICULO").HasMaxLength(255);
        builder.Property(x => x.IdVeiculo).HasColumnName("TX_ID_VEICULO").HasMaxLength(255);
        builder.Property(x => x.IdGuiaRemessa).HasColumnName("TX_ID_GUIA_REMESSA").HasMaxLength(255);

        builder.Property(x => x.DistanciaViaMetros)
            .HasColumnName("NR_DISTANCIA_DA_VIA_M")
            .HasPrecision(10, 2);

        builder.Property(x => x.OfereceRiscoSistemaCptm).HasColumnName("CD_OFERECE_RISCO_SISTEMA_CPTM").HasMaxLength(255);
        builder.Property(x => x.Proprietario).HasColumnName("CD_PROPRIETARIO").HasMaxLength(255);

        builder.Property(x => x.ObservacaoCadastramento)
            .HasColumnName("TX_OBS_CADASTRAMENTO")
            .HasMaxLength(2000);

        // =========================================
        // ID 45-51
        // =========================================

        builder.Property(x => x.DataCadastramento).HasColumnName("DT_DATA_DO_CADASTRAMENTO");
        builder.Property(x => x.HoraCadastramento).HasColumnName("HR_HORA_DO_CADASTRAMENTO").HasMaxLength(10);
        builder.Property(x => x.AutorPjCadastro).HasColumnName("TX_AUTOR_PJ_DO_CADASTRO").HasMaxLength(255);
        builder.Property(x => x.AutorPfCadastro).HasColumnName("TX_AUTOR_PF_DO_CADASTRO").HasMaxLength(255);
        builder.Property(x => x.NomeResponsavelCadastro).HasColumnName("TX_NM_RESPONSAVEL_CADASTRO").HasMaxLength(255);
        builder.Property(x => x.RegistroProfissionalCadastro).HasColumnName("TX_RP_RESPONSAVEL_CADASTRO").HasMaxLength(255);
        builder.Property(x => x.DocumentoResponsabilidadeTecnica).HasColumnName("TX_DRT_RESPONSAVEL_CADASTRO").HasMaxLength(255);

        // =========================================
        // ID 52-59
        // =========================================

        builder.Property(x => x.NomePjContratada).HasColumnName("TX_NOME_PJ_DA_CONTRATADA").HasMaxLength(255);
        builder.Property(x => x.NumeroContratoContratada).HasColumnName("TX_NR_CONTRATO_CONTRATADA").HasMaxLength(255);
        builder.Property(x => x.NomeAreaGestoraCptm).HasColumnName("CD_NM_AREA_GESTORA_CPTM").HasMaxLength(255);
        builder.Property(x => x.IdAreaGestoraCptm).HasColumnName("TX_ID_AREA_GESTORA_CPTM").HasMaxLength(255);
        builder.Property(x => x.SiglaAreaGestoraCptm).HasColumnName("TX_SIGLA_AREA_GESTORA_CPTM").HasMaxLength(255);
        builder.Property(x => x.NomeRepresentantePf).HasColumnName("TX_NOME_PF_DA_REPRESENTANTE").HasMaxLength(255);
        builder.Property(x => x.NomePjSupervisora).HasColumnName("TX_NOME_PJ_DA_SUPERVISORA").HasMaxLength(255);
        builder.Property(x => x.NumeroContratoSupervisora).HasColumnName("TX_NR_CONTRATO_SUPERVISORA").HasMaxLength(255);

        // =========================================
        // ID 60-69
        // =========================================

        builder.Property(x => x.NomeArquivoFdcRelacionado).HasColumnName("TX_NM_ARQUIVO_FDC_RELACIONADO").HasMaxLength(255);
        builder.Property(x => x.CodigoArquivoFdcRelacionado).HasColumnName("PK_CD_ARQUIVO_FDC_RELACIONADO").HasMaxLength(255);
        builder.Property(x => x.NomeArquivoRvtRelacionado).HasColumnName("TX_NM_ARQUIVO_RVT_RELACIONADO").HasMaxLength(255);
        builder.Property(x => x.CodigoElementoMonitorRvt).HasColumnName("PK_CD_ELEMENTO_DE_MONITOR_RVT").HasMaxLength(255);
        builder.Property(x => x.NomeArquivoDacRelacionado).HasColumnName("TX_NM_ARQUIVO_DAC_RELACIONADO").HasMaxLength(255);
        builder.Property(x => x.CodigoElementoMonitorDac).HasColumnName("PK_CD_ELEMENTO_DE_MONITOR_DAC").HasMaxLength(255);
        builder.Property(x => x.NomeArquivoCncRelacionado).HasColumnName("TX_NM_ARQUIVO_CNC_RELACIONADO").HasMaxLength(255);
        builder.Property(x => x.CodigoElementoMonitorCnc).HasColumnName("PK_CD_ELEMENTO_DE_MONITOR_CNC").HasMaxLength(255);
        builder.Property(x => x.CodigoUltimoRra).HasColumnName("PK_CD_CODIGO_NO_ULTIMO_RRA").HasMaxLength(255);
        builder.Property(x => x.CodigoCedoc).HasColumnName("PK_CD_CEDOC").HasMaxLength(255);

        // =========================================
        // ID 70-73
        // =========================================

        builder.Property(x => x.NomeFoto01).HasColumnName("TX_NOME_FOTO_01").HasMaxLength(255);
        builder.Property(x => x.NomeFoto02).HasColumnName("TX_NOME_FOTO_02").HasMaxLength(255);
        builder.Property(x => x.NomeFoto03).HasColumnName("TX_NOME_FOTO_03").HasMaxLength(255);
        builder.Property(x => x.NomeFoto04).HasColumnName("TX_NOME_FOTO_04").HasMaxLength(255);

        // =========================================
        // AUDITORIA
        // =========================================

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UPDATED_AT");

        builder.Property(x => x.IsDeleted)
            .HasColumnName("IS_DELETED")
            .HasConversion(
                v => v ? 1 : 0,
                v => v == 1
            );
    }
}