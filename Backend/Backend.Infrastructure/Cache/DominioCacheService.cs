using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class DominioCacheService
    : IDominioCacheService
{
    private readonly IServiceScopeFactory
        _scopeFactory;

    private readonly Dictionary<
        string,
        Dictionary<int, string>>
        _cache = new();

    public DominioCacheService(
        IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task LoadAsync()
    {
        using var scope =
            _scopeFactory.CreateScope();

        var context =
            scope.ServiceProvider
                .GetRequiredService<AppDbContext>();

        foreach (var dominio in
            DominioTableResolver.GetAll())
        {
            var sql = $@"
                SELECT
                    CD_CODIGO AS Codigo,
                    TX_DESCRICAO AS Descricao
                FROM {dominio.Value}";

            var itens =
                await context.Database
                    .SqlQueryRaw<DominioItem>(sql)
                    .ToListAsync();

            _cache[dominio.Key] =
                itens.ToDictionary(
                    x => x.Codigo,
                    x => x.Descricao);
        }
    }

    public string? GetDescricao(
        string dominio,
        int? codigo)
    {
        if (!codigo.HasValue)
            return null;

        if (!_cache.TryGetValue(
            dominio,
            out var tabela))
        {
            return null;
        }

        return tabela.TryGetValue(
            codigo.Value,
            out var descricao)
                ? descricao
                : null;
    }

    public bool Exists(
        string dominio,
        int codigo)
    {
        if (!_cache.ContainsKey(dominio))
            return false;

        return _cache[dominio]
            .ContainsKey(codigo);
    }
}