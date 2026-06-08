public class EfluenteResponse
{

        // ========================================
        // ID 1 a 3 - IDENTIFICAÇÃO DO E.M.
        // ========================================

        public string CodigoMeioAmbienteCptm { get; set; } = null!;

        public string? NumeroElementoMonitoramento { get; set; }

        public string? NomeElementoMonitoramento { get; set; }

        // ========================================
        // ID 4 a 6 - PREMISSAS INSTITUCIONAIS
        // ========================================

        public string? SiglaDepartamentoMeioAmbiente { get; set; }

        public string? StatusDesvioAmbiental { get; set; }

        public string? StatusRegistroBd { get; set; }

        // ========================================
        // ID 7 a 17 - LOCALIZAÇÃO
        // ========================================

        public string? Municipio { get; set; }

        public string? LinhaCptm { get; set; }

        public string? ViaCptm { get; set; }

        public string? TrechoSentidoCptm { get; set; }

        public string? KmPoste { get; set; }

        public string? EstacaoCptm { get; set; }

        public decimal? LatitudeGrauDecimalWgs84 { get; set; }

        public decimal? LongitudeGrauDecimalWgs84 { get; set; }

        public decimal? LatitudeMetrosSirgas2000 { get; set; }

        public decimal? LongitudeMetrosSirgas2000 { get; set; }

        public string? NomeLocalEscopoContratual { get; set; }

        // ========================================
        // ID 18 a 23 - FORMULÁRIO
        // ========================================

        public string? TipoFormulario { get; set; }

        public DateTime? DataEmissaoFormulario { get; set; }

        public int? NumeroFormulario { get; set; }

        public string? AutorPfFormulario { get; set; }

        public string? NaturezaPga { get; set; }

        public string? NomePjExecutora { get; set; }

        // ========================================
        // ID 24 a 30 - REGULAMENTAÇÃO AMBIENTAL
        // ========================================

        public string? TipoAtividadeListada { get; set; }

        public string? TipoAtividadeNaoListada { get; set; }

        public string? TipoDraListado { get; set; }

        public string? TipoDraNaoListado { get; set; }

        public string? IdDra { get; set; }

        public DateTime? ValidadeDra { get; set; }

        public string? AnaliseCptmAprovacao { get; set; }

        // ========================================
        // ID 31 a 44 - DETALHAMENTO
        // ========================================

        public string? TipoAtividadeCptm { get; set; }

        public string? NomeLocalAtividade { get; set; }

        public string? NomeLocalAtividadeComplemento { get; set; }

        public string? OrigemEfluente { get; set; }

        public string? FonteGeradora { get; set; }

        public decimal? QuantidadeLitros { get; set; }

        public string? TipoDestinacao { get; set; }

        public string? TipoVeiculo { get; set; }

        public string? IdVeiculo { get; set; }

        public string? IdGuiaRemessa { get; set; }

        public decimal? DistanciaViaMetros { get; set; }

        public string? OfereceRiscoSistemaCptm { get; set; }

        public string? Proprietario { get; set; }

        public string? ObservacaoCadastramento { get; set; }

        // ========================================
        // ID 45 a 51 - CADASTRO / RT
        // ========================================

        public DateTime? DataCadastramento { get; set; }

        public string? HoraCadastramento { get; set; }

        public string? AutorPjCadastro { get; set; }

        public string? AutorPfCadastro { get; set; }

        public string? NomeResponsavelCadastro { get; set; }

        public string? RegistroProfissionalCadastro { get; set; }

        public string? DocumentoResponsabilidadeTecnica { get; set; }

        // ========================================
        // ID 52 a 59 - CONTRATOS
        // ========================================

        public string? NomePjContratada { get; set; }

        public string? NumeroContratoContratada { get; set; }

        public string? NomeAreaGestoraCptm { get; set; }

        public string? IdAreaGestoraCptm { get; set; }

        public string? SiglaAreaGestoraCptm { get; set; }

        public string? NomeRepresentantePf { get; set; }

        public string? NomePjSupervisora { get; set; }

        public string? NumeroContratoSupervisora { get; set; }

        // ========================================
        // ID 60 a 69 - ARQUIVOS RELACIONADOS
        // ========================================

        public string? NomeArquivoFdcRelacionado { get; set; }

        public string? CodigoArquivoFdcRelacionado { get; set; }

        public string? NomeArquivoRvtRelacionado { get; set; }

        public string? CodigoElementoMonitorRvt { get; set; }

        public string? NomeArquivoDacRelacionado { get; set; }

        public string? CodigoElementoMonitorDac { get; set; }

        public string? NomeArquivoCncRelacionado { get; set; }

        public string? CodigoElementoMonitorCnc { get; set; }

        public string? CodigoUltimoRra { get; set; }

        public string? CodigoCedoc { get; set; }

        // ========================================
        // ID 70 a 73 - FOTOS
        // ========================================

        public string? NomeFoto01 { get; set; }

        public string? NomeFoto02 { get; set; }

        public string? NomeFoto03 { get; set; }

        public string? NomeFoto04 { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
}