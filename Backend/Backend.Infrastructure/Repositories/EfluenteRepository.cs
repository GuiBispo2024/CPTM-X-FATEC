using Microsoft.EntityFrameworkCore;

public class EfluenteRepository
    : IEfluenteRepository
{
    private readonly AppDbContext _context;

    public EfluenteRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(
        Efluente efluente)
    {
        await _context.Efluentes
            .AddAsync(efluente);

        await _context.SaveChangesAsync();
    }

    public async Task Update(
        Efluente efluente)
    {
        _context.Efluentes.Update(efluente);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(
    Efluente efluente)
    {
        _context.Efluentes.Update(efluente);

        await _context.SaveChangesAsync();
    }

    public async Task<Efluente?> GetById(
        int id)
    {
        return await _context.Efluentes
            .FirstOrDefaultAsync(
                e => e.Id == id &&
                     !e.IsDeleted
            );
    }

    public async Task<List<Efluente>> GetAll()
    {
        return await _context.Efluentes
            .Where(e => !e.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Efluente>>
        GetPendingSync()
    {
        return await _context.Efluentes
            .Where(
                e => e.SyncStatus ==
                     SyncStatus.Pending
            )
            .ToListAsync();
    }
}