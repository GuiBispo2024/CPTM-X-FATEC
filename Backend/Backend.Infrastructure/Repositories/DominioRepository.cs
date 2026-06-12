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
}