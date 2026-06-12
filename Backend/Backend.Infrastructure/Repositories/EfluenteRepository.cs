using Microsoft.EntityFrameworkCore;

public class EfluenteRepository : IEfluenteRepository
{
    private readonly AppDbContext _context;

    public EfluenteRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task<Efluente?> GetByIdAsync(
        string codigoMeioAmbienteCptm)
    {
        return await _context.Efluentes
            .FirstOrDefaultAsync(x =>
                x.CodigoMeioAmbienteCptm ==
                codigoMeioAmbienteCptm &&
                !x.IsDeleted);
    }

    public async Task<IEnumerable<Efluente>> GetAllAsync()
    {
        return await _context.Efluentes
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(
        string codigoMeioAmbienteCptm)
    {
        var count = await _context.Efluentes
            .CountAsync(x =>
                x.CodigoMeioAmbienteCptm ==
                codigoMeioAmbienteCptm &&
                !x.IsDeleted);

        return count > 0;
    }

    public async Task AddAsync(
        Efluente efluente)
    {
        await _context.Efluentes
            .AddAsync(efluente);
    }

    public Task UpdateAsync(
        Efluente efluente)
    {
        _context.Efluentes
            .Update(efluente);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(
        Efluente efluente)
    {
        _context.Efluentes
            .Update(efluente);

        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context
            .SaveChangesAsync();
    }
}