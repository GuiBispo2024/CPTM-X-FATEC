public class EfluenteResponse
{
    public int Id { get; set; }

    public Guid SyncId { get; set; }

    public SyncStatus SyncStatus { get; set; }

    public string? NomeContratada { get; set; }

    public string? NumeroContrato { get; set; }

    public string? SiglaDepartamentoMeioAmbiente { get; set; }

    public string? AreaGestoraCptm { get; set; }

    public string? DiretoriaCptm { get; set; }

    public string? ProgramaAmbiental { get; set; }

    public string? NaturezaPga { get; set; }

    public string? Municipio { get; set; }

    public string? LinhaCptm { get; set; }

    public string? ViaCptm { get; set; }

    public string? TrechoSentido { get; set; }

    public string? EstacaoCptm { get; set; }

    public string? Endereco { get; set; }

    public string? CoordenadaGeografica { get; set; }

    public string? TipoAtividade { get; set; }

    public string? TipoDra { get; set; }

    public string? TipoAtividadeCptm { get; set; }

    public string? NomeLocalAtividade { get; set; }

    public string? OrigemEfluente { get; set; }

    public string? FonteGeradora { get; set; }

    public string? TipoDestinacao { get; set; }

    public string? TipoVeiculo { get; set; }

    public string? StatusDesvioAmbiental { get; set; }

    public string? StatusRegistroBd { get; set; }

    public string? Observacao { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}