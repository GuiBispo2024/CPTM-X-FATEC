public interface IDominioRepository
{
    Task<IEnumerable<Dominio>> GetAsync(
        string tableName);
}