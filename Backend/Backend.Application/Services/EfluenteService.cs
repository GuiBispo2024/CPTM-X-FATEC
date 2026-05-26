public class EfluenteService : IEfluenteService
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
            request.SiglaDepartamentoMeioAmbiente,
            request.AreaGestoraCptm,
            request.DiretoriaCptm,
            request.ProgramaAmbiental,
            request.NaturezaPga,
            request.Municipio,
            request.LinhaCptm,
            request.ViaCptm,
            request.TrechoSentido,
            request.EstacaoCptm,
            request.Endereco,
            request.CoordenadaGeografica,
            request.TipoAtividade,
            request.TipoDra,
            request.TipoAtividadeCptm,
            request.NomeLocalAtividade,
            request.OrigemEfluente,
            request.FonteGeradora,
            request.TipoDestinacao,
            request.TipoVeiculo,
            request.StatusDesvioAmbiental,
            request.StatusRegistroBd,
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
            request.NomeContratada,
            request.NumeroContrato,
            request.SiglaDepartamentoMeioAmbiente,
            request.AreaGestoraCptm,
            request.DiretoriaCptm,
            request.ProgramaAmbiental,
            request.NaturezaPga,
            request.Municipio,
            request.LinhaCptm,
            request.ViaCptm,
            request.TrechoSentido,
            request.EstacaoCptm,
            request.Endereco,
            request.CoordenadaGeografica,
            request.TipoAtividade,
            request.TipoDra,
            request.TipoAtividadeCptm,
            request.NomeLocalAtividade,
            request.OrigemEfluente,
            request.FonteGeradora,
            request.TipoDestinacao,
            request.TipoVeiculo,
            request.StatusDesvioAmbiental,
            request.StatusRegistroBd,
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

    public async Task<EfluenteResponse> GetById(
        int id)
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
        var efluentes =
            await _repo.GetAll();

        return efluentes
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<List<EfluenteResponse>>
        GetPendingSync()
    {
        var efluentes =
            await _repo.GetPendingSync();

        return efluentes
            .Select(MapToResponse)
            .ToList();
    }

    private EfluenteResponse MapToResponse(
        Efluente e)
    {
        return new EfluenteResponse
        {
            Id = e.Id,
            SyncId = e.SyncId,
            SyncStatus = e.SyncStatus,

            NomeContratada = e.NomeContratada,
            NumeroContrato = e.NumeroContrato,
            SiglaDepartamentoMeioAmbiente =
                e.SiglaDepartamentoMeioAmbiente,
            AreaGestoraCptm =
                e.AreaGestoraCptm,
            DiretoriaCptm =
                e.DiretoriaCptm,
            ProgramaAmbiental =
                e.ProgramaAmbiental,
            NaturezaPga =
                e.NaturezaPga,

            Municipio = e.Municipio,
            LinhaCptm = e.LinhaCptm,
            ViaCptm = e.ViaCptm,
            TrechoSentido =
                e.TrechoSentido,
            EstacaoCptm =
                e.EstacaoCptm,
            Endereco = e.Endereco,
            CoordenadaGeografica =
                e.CoordenadaGeografica,

            TipoAtividade =
                e.TipoAtividade,
            TipoDra =
                e.TipoDra,
            TipoAtividadeCptm =
                e.TipoAtividadeCptm,
            NomeLocalAtividade =
                e.NomeLocalAtividade,
            OrigemEfluente =
                e.OrigemEfluente,
            FonteGeradora =
                e.FonteGeradora,
            TipoDestinacao =
                e.TipoDestinacao,
            TipoVeiculo =
                e.TipoVeiculo,

            StatusDesvioAmbiental =
                e.StatusDesvioAmbiental,

            StatusRegistroBd =
                e.StatusRegistroBd,

            Observacao = e.Observacao,

            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            IsDeleted = e.IsDeleted
        };
    }
}