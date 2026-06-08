using Microsoft.EntityFrameworkCore;

public class DominioRepository : IDominioRepository
{
    private readonly AppDbContext _context;

    public DominioRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dominio>> GetAsync(
        string tableName)
    {
        var sql = $@"
            SELECT
                CD_CODIGO AS Codigo,
                TX_DESCRICAO AS Descricao
            FROM {tableName}
            ORDER BY CD_CODIGO";

        return await _context.Database
            .SqlQueryRaw<Dominio>(sql)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(
        string tableName,
        int codigo)
    {
        var sql = $@"
            SELECT
                CD_CODIGO AS Codigo,
                TX_DESCRICAO AS Descricao
            FROM {tableName}
            WHERE CD_CODIGO = {codigo}";

        var result = await _context.Database
            .SqlQueryRaw<Dominio>(sql)
            .ToListAsync();

        return result.Any();
    }

    public async Task<string?> GetDescricaoAsync(
        string tableName,
        int codigo)
    {
        var sql = $@"
            SELECT TX_DESCRICAO ""Value""
            FROM {tableName}
            WHERE CD_CODIGO = {codigo}";

        return await _context.Database
            .SqlQueryRaw<string>(sql)
            .FirstOrDefaultAsync();
    }
}