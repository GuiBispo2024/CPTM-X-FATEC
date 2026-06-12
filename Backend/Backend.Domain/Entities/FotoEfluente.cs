namespace Backend.Domain.Entities;

public class FotoEfluente
{
    // Corresponde a PK_CD_FOTO_EFLUENTE
    public int Id { get; private set; } 

    // Chave Estrangeira para a tabela de Efluentes
    public string EfluenteId { get; private set; } = null!; 
    
    // O arquivo da foto em si (Mapeado como BLOB no Oracle)
    public byte[]? Conteudo { get; private set; } 

    public string? Legenda { get; private set; }
    public DateTime DataRegistro { get; private set; }

    // Propriedade de navegação: permite acessar os dados do efluente a partir da foto
    public Efluente? Efluente { get; private set; }

    protected FotoEfluente() { } // Construtor para o EF Core

    public FotoEfluente(string efluenteId, byte[] conteudo, string legenda)
    {
        EfluenteId = efluenteId;
        Conteudo = conteudo;
        Legenda = legenda;
        DataRegistro = DateTime.Now;
    }
}