public interface IEfluenteService
{
    Task<EfluenteResponse> Create(
        CreateEfluenteRequest request);

    Task Update(
        int id,
        UpdateEfluenteRequest request);

    Task Delete(int id);

    Task<EfluenteResponse> GetById(int id);

    Task<List<EfluenteResponse>> GetAll();
}