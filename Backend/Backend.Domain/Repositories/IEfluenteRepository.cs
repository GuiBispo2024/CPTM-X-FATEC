public interface IEfluenteRepository
{
    Task Add(Efluente efluente);

    Task Update(Efluente efluente);

    Task Delete(Efluente efluente);

    Task<Efluente?> GetById(int id);

    Task<List<Efluente>> GetAll();

    Task<List<Efluente>> GetPendingSync();
}