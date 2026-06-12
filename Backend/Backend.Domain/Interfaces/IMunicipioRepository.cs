using Backend.Domain.Entities;

namespace Backend.Domain;

public interface IMunicipioRepository
{
    Task<IEnumerable<Municipio>> ObterTodosAsync();
}