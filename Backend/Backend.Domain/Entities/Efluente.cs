public class Efluente
{
    public int Id { get; private set; }

    // ========================================
    // OFFLINE / SYNC
    // ========================================

    public Guid SyncId { get; private set; }

    public SyncStatus SyncStatus { get; private set; }

    // ========================================
    // INSTITUCIONAL
    // ========================================

    public string? NomeContratada { get; private set; }

    public string? NumeroContrato { get; private set; }

    public string? SiglaDepartamentoMeioAmbiente { get; private set; }

    public string? AreaGestoraCptm { get; private set; }

    public string? DiretoriaCptm { get; private set; }

    public string? ProgramaAmbiental { get; private set; }

    public string? NaturezaPga { get; private set; }

    // ========================================
    // LOCALIZAÇÃO
    // ========================================

    public string? Municipio { get; private set; }

    public string? LinhaCptm { get; private set; }

    public string? ViaCptm { get; private set; }

    public string? TrechoSentido { get; private set; }

    public string? EstacaoCptm { get; private set; }

    public string? Endereco { get; private set; }

    public string? CoordenadaGeografica { get; private set; }

    // ========================================
    // CARACTERIZAÇÃO
    // ========================================

    public string? TipoAtividade { get; private set; }

    public string? TipoDra { get; private set; }

    public string? TipoAtividadeCptm { get; private set; }

    public string? NomeLocalAtividade { get; private set; }

    public string? OrigemEfluente { get; private set; }

    public string? FonteGeradora { get; private set; }

    public string? TipoDestinacao { get; private set; }

    public string? TipoVeiculo { get; private set; }

    // ========================================
    // CONTROLE
    // ========================================

    public string? StatusDesvioAmbiental { get; private set; }

    public string? StatusRegistroBd { get; private set; }

    public string? Observacao { get; private set; }

    // ========================================
    // AUDITORIA
    // ========================================

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public bool IsDeleted { get; private set; }

    protected Efluente() { }

    public Efluente(
        string nomeContratada,
        string numeroContrato,
        string siglaDepartamentoMeioAmbiente,
        string areaGestoraCptm,
        string diretoriaCptm,
        string programaAmbiental,
        string naturezaPga,
        string municipio,
        string linhaCptm,
        string viaCptm,
        string trechoSentido,
        string estacaoCptm,
        string endereco,
        string coordenadaGeografica,
        string tipoAtividade,
        string tipoDra,
        string tipoAtividadeCptm,
        string nomeLocalAtividade,
        string origemEfluente,
        string fonteGeradora,
        string tipoDestinacao,
        string tipoVeiculo,
        string statusDesvioAmbiental,
        string statusRegistroBd,
        string observacao)
    {
        NomeContratada = nomeContratada;
        NumeroContrato = numeroContrato;
        SiglaDepartamentoMeioAmbiente =
            siglaDepartamentoMeioAmbiente;
        AreaGestoraCptm = areaGestoraCptm;
        DiretoriaCptm = diretoriaCptm;
        ProgramaAmbiental = programaAmbiental;
        NaturezaPga = naturezaPga;

        Municipio = municipio;
        LinhaCptm = linhaCptm;
        ViaCptm = viaCptm;
        TrechoSentido = trechoSentido;
        EstacaoCptm = estacaoCptm;
        Endereco = endereco;
        CoordenadaGeografica =
            coordenadaGeografica;

        TipoAtividade = tipoAtividade;
        TipoDra = tipoDra;
        TipoAtividadeCptm =
            tipoAtividadeCptm;
        NomeLocalAtividade =
            nomeLocalAtividade;
        OrigemEfluente = origemEfluente;
        FonteGeradora = fonteGeradora;
        TipoDestinacao = tipoDestinacao;
        TipoVeiculo = tipoVeiculo;

        StatusDesvioAmbiental =
            statusDesvioAmbiental;

        StatusRegistroBd =
            statusRegistroBd;

        Observacao = observacao;

        SyncId = Guid.NewGuid();

        SyncStatus = SyncStatus.Pending;

        CreatedAt = DateTime.UtcNow;

        UpdatedAt = DateTime.UtcNow;

        IsDeleted = false;
    }

    public void Update(
        string? nomeContratada,
        string? numeroContrato,
        string? siglaDepartamentoMeioAmbiente,
        string? areaGestoraCptm,
        string? diretoriaCptm,
        string? programaAmbiental,
        string? naturezaPga,
        string? municipio,
        string? linhaCptm,
        string? viaCptm,
        string? trechoSentido,
        string? estacaoCptm,
        string? endereco,
        string? coordenadaGeografica,
        string? tipoAtividade,
        string? tipoDra,
        string? tipoAtividadeCptm,
        string? nomeLocalAtividade,
        string? origemEfluente,
        string? fonteGeradora,
        string? tipoDestinacao,
        string? tipoVeiculo,
        string? statusDesvioAmbiental,
        string? statusRegistroBd,
        string? observacao)
    {
        NomeContratada = nomeContratada;

        NumeroContrato = numeroContrato;

        SiglaDepartamentoMeioAmbiente =
            siglaDepartamentoMeioAmbiente;

        AreaGestoraCptm =
            areaGestoraCptm;

        DiretoriaCptm =
            diretoriaCptm;

        ProgramaAmbiental =
            programaAmbiental;

        NaturezaPga =
            naturezaPga;

        Municipio = municipio;

        LinhaCptm = linhaCptm;

        ViaCptm = viaCptm;

        TrechoSentido =
            trechoSentido;

        EstacaoCptm =
            estacaoCptm;

        Endereco = endereco;

        CoordenadaGeografica =
            coordenadaGeografica;

        TipoAtividade =
            tipoAtividade;

        TipoDra =
            tipoDra;

        TipoAtividadeCptm =
            tipoAtividadeCptm;

        NomeLocalAtividade =
            nomeLocalAtividade;

        OrigemEfluente =
            origemEfluente;

        FonteGeradora =
            fonteGeradora;

        TipoDestinacao =
            tipoDestinacao;

        TipoVeiculo =
            tipoVeiculo;

        StatusDesvioAmbiental =
            statusDesvioAmbiental;

        StatusRegistroBd =
            statusRegistroBd;

        Observacao =
            observacao;

        UpdatedAt = DateTime.UtcNow;

        SyncStatus = SyncStatus.Pending;
    }

    public void Delete()
    {
        IsDeleted = true;

        UpdatedAt = DateTime.UtcNow;

        SyncStatus = SyncStatus.Pending;
    }
}