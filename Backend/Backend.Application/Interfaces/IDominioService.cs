public interface IDominioService
{
    Task<IEnumerable<DominioResponse>>
        GetAsync(string dominio);
}