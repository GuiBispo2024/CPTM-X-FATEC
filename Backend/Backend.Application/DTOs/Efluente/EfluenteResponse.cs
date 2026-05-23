public class EfluenteResponse
{
    public int Id { get; set; }

    public string NomeContratada { get; set; } = null!;

    public string NumeroContrato { get; set; } = null!;

    public string ProgramaAmbiental { get; set; } = null!;

    public string Natureza { get; set; } = null!;

    public string LinhaCptm { get; set; } = null!;

    public string ViaCptm { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public string CoordenadaGeografica { get; set; } = null!;

    public string TipoEfluente { get; set; } = null!;

    public string StatusDesvioAmbiental { get; set; } = null!;

    public string Observacao { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public Guid SyncId { get; set; }

    public string SyncStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}