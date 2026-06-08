public interface IEfluenteRepository
{
    Task<Efluente?> GetByIdAsync(string codigoMeioAmbienteCptm);

    Task<IEnumerable<Efluente>> GetAllAsync();

    Task<bool> ExistsAsync(string codigoMeioAmbienteCptm);

    Task AddAsync(Efluente efluente);

    Task UpdateAsync(Efluente efluente);

    Task DeleteAsync(Efluente efluente);

    Task<int> SaveChangesAsync();

}