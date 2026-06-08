public interface IEfluenteService
{
    Task<EfluenteResponse> GetByIdAsync(
        string codigoMeioAmbienteCptm);

    Task<IEnumerable<EfluenteResponse>> GetAllAsync();

    Task<EfluenteResponse> CreateAsync(
        CreateEfluenteRequest request);

    Task UpdateAsync(
        string codigoMeioAmbienteCptm,
        UpdateEfluenteRequest request);

    Task DeleteAsync(
        string codigoMeioAmbienteCptm);
}