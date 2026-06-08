public interface IDominioRepository
{
    Task<IEnumerable<Dominio>> GetAsync(
        string tableName);

    Task<bool> ExistsAsync(
        string tableName,
        int codigo);

    Task<string?> GetDescricaoAsync(
        string tableName,
        int codigo);
}