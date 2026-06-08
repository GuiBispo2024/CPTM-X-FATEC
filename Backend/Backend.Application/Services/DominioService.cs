using AutoMapper;

public class DominioService
    : IDominioService
{
    private readonly IDominioRepository _repository;
    private readonly IMapper _mapper;

    public DominioService(
        IDominioRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DominioResponse>>
        GetAsync(string dominio)
    {
        var tableName =
            DominioTableResolver.GetTableName(
                dominio);

        var dados =
            await _repository.GetAsync(
                tableName);

        return _mapper.Map<
            IEnumerable<DominioResponse>>(
            dados);
    }

}