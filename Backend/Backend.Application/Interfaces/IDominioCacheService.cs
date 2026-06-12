public interface IDominioCacheService
{
    string? GetDescricao(
        string dominio,
        int? codigo);

    bool Exists(
        string dominio,
        int codigo);

    Task LoadAsync();
}