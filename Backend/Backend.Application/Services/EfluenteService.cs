public class EfluenteService
    : IEfluenteService
{
    private readonly IEfluenteRepository _repo;

    public EfluenteService(
        IEfluenteRepository repo)
    {
        _repo = repo;
    }

    public async Task<EfluenteResponse> Create(
        CreateEfluenteRequest request)
    {
        var efluente = new Efluente(
            request.NomeContratada,
            request.NumeroContrato,
            request.LinhaCptm,
            request.ViaCptm,
            request.Municipio,
            request.Endereco,
            request.CoordenadaGeografica,
            request.TipoEfluente,
            request.StatusDesvioAmbiental,
            request.Observacao
        );

        await _repo.Add(efluente);

        return MapToResponse(efluente);
    }

    public async Task Update(
        int id,
        UpdateEfluenteRequest request)
    {
        var efluente =
            await _repo.GetById(id);

        if (efluente == null)
            throw new Exception(
                "Efluente não encontrado"
            );

        efluente.Update(
            request.LinhaCptm,
            request.ViaCptm,
            request.Municipio,
            request.Endereco,
            request.CoordenadaGeografica,
            request.TipoEfluente,
            request.StatusDesvioAmbiental,
            request.Observacao
        );

        await _repo.Update(efluente);
    }

    public async Task Delete(int id)
    {
        var efluente =
            await _repo.GetById(id);

        if (efluente == null)
            throw new Exception(
                "Efluente não encontrado"
            );

        efluente.Delete();

        await _repo.Update(efluente);
    }

    public async Task<EfluenteResponse>
        GetById(int id)
    {
        var efluente =
            await _repo.GetById(id);

        if (efluente == null)
            throw new Exception(
                "Efluente não encontrado"
            );

        return MapToResponse(efluente);
    }

    public async Task<List<EfluenteResponse>>
        GetAll()
    {
        var list = await _repo.GetAll();

        return list
            .Select(MapToResponse)
            .ToList();
    }

    private EfluenteResponse MapToResponse(
        Efluente e)
    {
        return new EfluenteResponse
        {
            Id = e.Id,
            NomeContratada = e.NomeContratada,
            NumeroContrato = e.NumeroContrato,
            ProgramaAmbiental =
                e.ProgramaAmbiental,
            Natureza = e.Natureza,
            LinhaCptm = e.LinhaCptm,
            ViaCptm = e.ViaCptm,
            Municipio = e.Municipio,
            Endereco = e.Endereco,
            CoordenadaGeografica =
                e.CoordenadaGeografica,
            TipoEfluente =
                e.TipoEfluente,
            StatusDesvioAmbiental =
                e.StatusDesvioAmbiental,
            Observacao = e.Observacao,
            DataCadastro =
                e.DataCadastro,
            SyncId = e.SyncId,
            SyncStatus = e.SyncStatus,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            IsDeleted = e.IsDeleted,
        };
    }

    public async Task<List<EfluenteResponse>> GetPendingSync()
    {
        var list =
            await _repo.GetPendingSync();

        return list
            .Select(MapToResponse)
            .ToList();
    }
}