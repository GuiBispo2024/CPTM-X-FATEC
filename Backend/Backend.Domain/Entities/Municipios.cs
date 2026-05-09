namespace Backend.Domain.Entities;

public class Municipio
{
    // Corresponde a PK_CD_MUNICIPIO
    public int Codigo { get; private set; } 
    
    // Corresponde a TX_NM_MUNICIPIO
    public string Nome { get; private set; } = null!;

    // Construtor vazio exigido pelo Entity Framework
    protected Municipio() { } 

    public Municipio(int codigo, string nome)
    {
        Codigo = codigo;
        Nome = nome;
    }
}