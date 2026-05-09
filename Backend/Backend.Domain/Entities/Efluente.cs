namespace Backend.Domain.Entities;

public class Efluente
{
    public string Id { get; private set; } = null!; // PK_CD_MEIO_AMBIENTE_CPTM
    public string? NumeroElemento { get; private set; } // TX_NR_ELEMENTO_MONITORAMENTO
    public string? NomeElemento { get; private set; } // TX_NM_ELEMENTO_MONITORAMENTO
    public double? Latitude { get; private set; } // NR_LAT_GRAU_DECIMAL_WGS84
    public double? Longitude { get; private set; } // NR_LONG_GRAU_DECIMAL_WGS84
    public DateTime DataEmissao { get; private set; } // DT_DATA_EMISSAO_FORMULARIO
    public string Status { get; private set; } = "ATIVO"; // TX_STATUS_DO_REGISTRO_NO_BD
    public string? DetalheLocalizacao { get; private set; } // Campo descritivo 

    // A chave estrangeira para o Município (FK_CD_MUNICIPIO)
    public int? MunicipioId { get; private set; } 
    public Municipio? Municipio { get; private set; } // Propriedade de navegação

    protected Efluente() { } // Construtor para o EF Core
}