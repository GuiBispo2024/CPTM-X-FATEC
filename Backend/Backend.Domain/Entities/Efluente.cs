public class Efluente
{
    public int Id { get; private set; }

    // Institucional
    public string NomeContratada { get; private set; } = null!;

    public string NumeroContrato { get; private set; } = null!;

    public string ProgramaAmbiental { get; private set; } = null!;

    public string Natureza { get; private set; } = null!;

    // Caracterização
    public string LinhaCptm { get; private set; } = null!;

    public string ViaCptm { get; private set; } = null!;

    public string Municipio { get; private set; } = null!;

    public string Endereco { get; private set; } = null!;

    public string CoordenadaGeografica { get; private set; } = null!;

    public string TipoEfluente { get; private set; } = null!;

    public string StatusDesvioAmbiental { get; private set; } = null!;

    public string Observacao { get; private set; } = null!;

    // Controle
    public DateTime DataCadastro { get; private set; }

    protected Efluente() { }

    public Efluente(
        string nomeContratada,
        string numeroContrato,
        string linhaCptm,
        string viaCptm,
        string municipio,
        string endereco,
        string coordenadaGeografica,
        string tipoEfluente,
        string statusDesvioAmbiental,
        string observacao)
    {
        Validate(
            nomeContratada,
            numeroContrato,
            linhaCptm,
            viaCptm,
            municipio
        );

        NomeContratada = nomeContratada;
        NumeroContrato = numeroContrato;

        ProgramaAmbiental =
            "Efluentes e Emissões Atmosféricas - EEA";

        Natureza = "Efluentes - EF";

        LinhaCptm = linhaCptm;
        ViaCptm = viaCptm;
        Municipio = municipio;
        Endereco = endereco;
        CoordenadaGeografica = coordenadaGeografica;
        TipoEfluente = tipoEfluente;
        StatusDesvioAmbiental = statusDesvioAmbiental;
        Observacao = observacao;

        DataCadastro = DateTime.UtcNow;
    }

    public void Update(
        string linhaCptm,
        string viaCptm,
        string municipio,
        string endereco,
        string coordenadaGeografica,
        string tipoEfluente,
        string statusDesvioAmbiental,
        string observacao)
    {
        ValidateBasic(
            linhaCptm,
            viaCptm,
            municipio
        );

        LinhaCptm = linhaCptm;
        ViaCptm = viaCptm;
        Municipio = municipio;
        Endereco = endereco;
        CoordenadaGeografica = coordenadaGeografica;
        TipoEfluente = tipoEfluente;
        StatusDesvioAmbiental = statusDesvioAmbiental;
        Observacao = observacao;
    }

    private void Validate(
        string nomeContratada,
        string numeroContrato,
        string linhaCptm,
        string viaCptm,
        string municipio)
    {
        if (string.IsNullOrWhiteSpace(nomeContratada))
            throw new Exception("Nome da contratada obrigatório");

        if (string.IsNullOrWhiteSpace(numeroContrato))
            throw new Exception("Número do contrato obrigatório");

        ValidateBasic(
            linhaCptm,
            viaCptm,
            municipio
        );
    }

    private void ValidateBasic(
        string linhaCptm,
        string viaCptm,
        string municipio)
    {
        if (string.IsNullOrWhiteSpace(linhaCptm))
            throw new Exception("Linha CPTM obrigatória");

        if (string.IsNullOrWhiteSpace(viaCptm))
            throw new Exception("Via CPTM obrigatória");

        if (string.IsNullOrWhiteSpace(municipio))
            throw new Exception("Município obrigatório");
    }
}