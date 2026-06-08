public class Efluente
{
    // ========================================
    // ID 1 a 3 - IDENTIFICAÇÃO DO E.M.
    // ========================================

    public string CodigoMeioAmbienteCptm { get; private set; } = null!;

    public string? NumeroElementoMonitoramento { get; private set; }

    public string? NomeElementoMonitoramento { get; private set; }

    // ========================================
    // ID 4 a 6 - PREMISSAS INSTITUCIONAIS
    // ========================================

    public int? SiglaDepartamentoMeioAmbiente { get; private set; }

    public int? StatusDesvioAmbiental { get; private set; }

    public int? StatusRegistroBd { get; private set; }

    // ========================================
    // ID 7 a 17 - LOCALIZAÇÃO
    // ========================================

    public int? Municipio { get; private set; }

    public int? LinhaCptm { get; private set; }

    public int? ViaCptm { get; private set; }

    public int? TrechoSentidoCptm { get; private set; }

    public string? KmPoste { get; private set; }

    public int? EstacaoCptm { get; private set; }

    public decimal? LatitudeGrauDecimalWgs84 { get; private set; }

    public decimal? LongitudeGrauDecimalWgs84 { get; private set; }

    public decimal? LatitudeMetrosSirgas2000 { get; private set; }

    public decimal? LongitudeMetrosSirgas2000 { get; private set; }

    public string? NomeLocalEscopoContratual { get; private set; }

    // ========================================
    // ID 18 a 23 - FORMULÁRIO
    // ========================================

    public string? TipoFormulario { get; private set; }

    public DateTime? DataEmissaoFormulario { get; private set; }

    public int? NumeroFormulario { get; private set; }

    public string? AutorPfFormulario { get; private set; }

    public int? NaturezaPga { get; private set; }

    public string? NomePjExecutora { get; private set; }

    // ========================================
    // ID 24 a 30 - REGULAMENTAÇÃO AMBIENTAL
    // ========================================

    public int? TipoAtividadeListada { get; private set; }

    public string? TipoAtividadeNaoListada { get; private set; }

    public int? TipoDraListado { get; private set; }

    public string? TipoDraNaoListado { get; private set; }

    public string? IdDra { get; private set; }

    public DateTime? ValidadeDra { get; private set; }

    public string? AnaliseCptmAprovacao { get; private set; }

    // ========================================
    // ID 31 a 44 - DETALHAMENTO
    // ========================================

    public int? TipoAtividadeCptm { get; private set; }

    public int? NomeLocalAtividade { get; private set; }

    public string? NomeLocalAtividadeComplemento { get; private set; }

    public int? OrigemEfluente { get; private set; }

    public int? FonteGeradora { get; private set; }

    public decimal? QuantidadeLitros { get; private set; }

    public int? TipoDestinacao { get; private set; }

    public int? TipoVeiculo { get; private set; }

    public string? IdVeiculo { get; private set; }

    public string? IdGuiaRemessa { get; private set; }

    public decimal? DistanciaViaMetros { get; private set; }

    public int? OfereceRiscoSistemaCptm { get; private set; }

    public int? Proprietario { get; private set; }

    public string? ObservacaoCadastramento { get; private set; }

    // ========================================
    // ID 45 a 51 - CADASTRO / RT
    // ========================================

    public DateTime? DataCadastramento { get; private set; }

    public string? HoraCadastramento { get; private set; }

    public string? AutorPjCadastro { get; private set; }

    public string? AutorPfCadastro { get; private set; }

    public string? NomeResponsavelCadastro { get; private set; }

    public string? RegistroProfissionalCadastro { get; private set; }

    public string? DocumentoResponsabilidadeTecnica { get; private set; }

    // ========================================
    // ID 52 a 59 - CONTRATOS
    // ========================================

    public string? NomePjContratada { get; private set; }

    public string? NumeroContratoContratada { get; private set; }

    public int? NomeAreaGestoraCptm { get; private set; }

    public string? IdAreaGestoraCptm { get; private set; }

    public string? SiglaAreaGestoraCptm { get; private set; }

    public string? NomeRepresentantePf { get; private set; }

    public string? NomePjSupervisora { get; private set; }

    public string? NumeroContratoSupervisora { get; private set; }

    // ========================================
    // ID 60 a 69 - ARQUIVOS RELACIONADOS
    // ========================================

    public string? NomeArquivoFdcRelacionado { get; private set; }

    public string? CodigoArquivoFdcRelacionado { get; private set; }

    public string? NomeArquivoRvtRelacionado { get; private set; }

    public string? CodigoElementoMonitorRvt { get; private set; }

    public string? NomeArquivoDacRelacionado { get; private set; }

    public string? CodigoElementoMonitorDac { get; private set; }

    public string? NomeArquivoCncRelacionado { get; private set; }

    public string? CodigoElementoMonitorCnc { get; private set; }

    public string? CodigoUltimoRra { get; private set; }

    public string? CodigoCedoc { get; private set; }

    // ========================================
    // ID 70 a 73 - FOTOS
    // ========================================

    public string? NomeFoto01 { get; private set; }

    public string? NomeFoto02 { get; private set; }

    public string? NomeFoto03 { get; private set; }

    public string? NomeFoto04 { get; private set; }

    // ========================================
    // AUDITORIA
    // ========================================

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public bool IsDeleted { get; private set; }

    protected Efluente() { }

    private void Apply(EfluenteData data)
    {
        CodigoMeioAmbienteCptm = data.CodigoMeioAmbienteCptm;
        NumeroElementoMonitoramento = data.NumeroElementoMonitoramento;
        NomeElementoMonitoramento = data.NomeElementoMonitoramento;
        SiglaDepartamentoMeioAmbiente = data.SiglaDepartamentoMeioAmbiente;
        StatusDesvioAmbiental = data.StatusDesvioAmbiental;
        StatusRegistroBd = data.StatusRegistroBd;
        Municipio = data.Municipio;
        LinhaCptm = data.LinhaCptm;
        ViaCptm = data.ViaCptm;
        TrechoSentidoCptm = data.TrechoSentidoCptm;
        KmPoste = data.KmPoste;
        EstacaoCptm = data.EstacaoCptm;
        LatitudeGrauDecimalWgs84 = data.LatitudeGrauDecimalWgs84;
        LongitudeGrauDecimalWgs84 = data.LongitudeGrauDecimalWgs84;
        LatitudeMetrosSirgas2000 = data.LatitudeMetrosSirgas2000;
        LongitudeMetrosSirgas2000 = data.LongitudeMetrosSirgas2000;
        NomeLocalEscopoContratual = data.NomeLocalEscopoContratual;
        TipoFormulario = data.TipoFormulario;
        DataEmissaoFormulario = data.DataEmissaoFormulario;
        NumeroFormulario = data.NumeroFormulario;
        AutorPfFormulario = data.AutorPfFormulario;
        NaturezaPga = data.NaturezaPga;
        NomePjExecutora = data.NomePjExecutora;
        TipoAtividadeListada = data.TipoAtividadeListada;
        TipoAtividadeNaoListada = data.TipoAtividadeNaoListada;
        TipoDraListado = data.TipoDraListado;
        TipoDraNaoListado = data.TipoDraNaoListado;
        IdDra = data.IdDra;
        ValidadeDra = data.ValidadeDra;
        AnaliseCptmAprovacao = data.AnaliseCptmAprovacao;
        TipoAtividadeCptm = data.TipoAtividadeCptm;
        NomeLocalAtividade = data.NomeLocalAtividade;
        NomeLocalAtividadeComplemento = data.NomeLocalAtividadeComplemento;
        OrigemEfluente = data.OrigemEfluente;
        FonteGeradora = data.FonteGeradora;
        QuantidadeLitros = data.QuantidadeLitros;
        TipoDestinacao = data.TipoDestinacao;
        TipoVeiculo = data.TipoVeiculo;
        IdVeiculo = data.IdVeiculo;
        IdGuiaRemessa = data.IdGuiaRemessa;
        DistanciaViaMetros = data.DistanciaViaMetros;
        OfereceRiscoSistemaCptm = data.OfereceRiscoSistemaCptm;
        Proprietario = data.Proprietario;
        ObservacaoCadastramento = data.ObservacaoCadastramento;
        DataCadastramento = data.DataCadastramento;
        HoraCadastramento = data.HoraCadastramento;
        AutorPjCadastro = data.AutorPjCadastro;
        AutorPfCadastro = data.AutorPfCadastro;
        NomeResponsavelCadastro = data.NomeResponsavelCadastro;
        RegistroProfissionalCadastro = data.RegistroProfissionalCadastro;
        DocumentoResponsabilidadeTecnica = data.DocumentoResponsabilidadeTecnica;
        NomePjContratada = data.NomePjContratada;
        NumeroContratoContratada = data.NumeroContratoContratada;
        NomeAreaGestoraCptm = data.NomeAreaGestoraCptm;
        IdAreaGestoraCptm = data.IdAreaGestoraCptm;
        SiglaAreaGestoraCptm = data.SiglaAreaGestoraCptm;
        NomeRepresentantePf = data.NomeRepresentantePf;
        NomePjSupervisora = data.NomePjSupervisora;
        NumeroContratoSupervisora = data.NumeroContratoSupervisora;
        NomeArquivoFdcRelacionado = data.NomeArquivoFdcRelacionado;
        CodigoArquivoFdcRelacionado = data.CodigoArquivoFdcRelacionado;
        NomeArquivoRvtRelacionado = data.NomeArquivoRvtRelacionado;
        CodigoElementoMonitorRvt = data.CodigoElementoMonitorRvt;
        NomeArquivoDacRelacionado = data.NomeArquivoDacRelacionado;
        CodigoElementoMonitorDac = data.CodigoElementoMonitorDac;
        NomeArquivoCncRelacionado = data.NomeArquivoCncRelacionado;
        CodigoElementoMonitorCnc = data.CodigoElementoMonitorCnc;
        CodigoUltimoRra = data.CodigoUltimoRra;
        CodigoCedoc = data.CodigoCedoc;
        NomeFoto01 = data.NomeFoto01;
        NomeFoto02 = data.NomeFoto02;
        NomeFoto03 = data.NomeFoto03;
        NomeFoto04 = data.NomeFoto04;
    }

    public Efluente(EfluenteData data)
    {
        Apply(data);

        CreatedAt = DateTime.UtcNow;

        UpdatedAt = DateTime.UtcNow;

        IsDeleted = false;
    }

    public void Update(EfluenteData data)
    {
        Apply(data);

        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;

        UpdatedAt = DateTime.UtcNow;
    }
}