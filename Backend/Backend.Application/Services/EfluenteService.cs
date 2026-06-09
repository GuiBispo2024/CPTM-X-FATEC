using AutoMapper;

public class EfluenteService : IEfluenteService
{
    private readonly IEfluenteRepository _repository;
    private readonly IDominioRepository _dominioRepository;
    private readonly IMapper _mapper;
    private readonly IDominioCacheService _dominioCacheService;

    public EfluenteService(
        IEfluenteRepository repository,
        IDominioRepository dominioRepository,
        IMapper mapper,
        IDominioCacheService dominioCacheService)
    {
        _repository = repository;
        _dominioRepository = dominioRepository;
        _mapper = mapper;
        _dominioCacheService = dominioCacheService;
    }

    public async Task<EfluenteResponse>
     GetByIdAsync(
         string codigoMeioAmbienteCptm)
    {
        var efluente =
            await GetEntityAsync(
                codigoMeioAmbienteCptm);

        var response =
            _mapper.Map<EfluenteResponse>(
                efluente);

        response.SiglaDepartamentoMeioAmbiente =
            ObterDescricaoDominio(
                 efluente.SiglaDepartamentoMeioAmbiente,
                 "Sigla Departamento Meio Ambiente");

        response.StatusDesvioAmbiental =
            ObterDescricaoDominio(
                efluente.StatusDesvioAmbiental,
                "Status Desvio Ambiental");

        response.StatusRegistroBd =
            ObterDescricaoDominio(
                efluente.StatusRegistroBd,
                "Status Registro BD");

        response.Municipio =
            ObterDescricaoDominio(
                efluente.Municipio,
                "Municipio");

        response.LinhaCptm =
            ObterDescricaoDominio(
                efluente.LinhaCptm,
                "Linha CPTM");

        response.ViaCptm =
            ObterDescricaoDominio(
                efluente.ViaCptm,
                "Via CPTM");

        response.TrechoSentidoCptm =
            ObterDescricaoDominio(
                efluente.TrechoSentidoCptm,
                "Trecho e Sentido CPTM");

        response.EstacaoCptm =
            ObterDescricaoDominio(
                efluente.EstacaoCptm,
                "Estacao CPTM");

        response.NaturezaPga =
            ObterDescricaoDominio(
                efluente.NaturezaPga,
                "Natureza do PGA");

        response.TipoAtividadeListada =
            ObterDescricaoDominio(
                efluente.TipoAtividadeListada,
                "Tipo Atividade Listada");

        response.TipoDraListado =
            ObterDescricaoDominio(
                efluente.TipoDraListado,
                "Tipo DRA Listado");

        response.TipoAtividadeCptm =
            ObterDescricaoDominio(
                efluente.TipoAtividadeCptm,
                "Tipo Atividade CPTM");

        response.NomeLocalAtividade =
            ObterDescricaoDominio(
                efluente.NomeLocalAtividade,
                "Nome Local Atividade");

        response.OrigemEfluente =
            ObterDescricaoDominio(
                efluente.OrigemEfluente,
                "Origem Efluente");

        response.FonteGeradora =
            ObterDescricaoDominio(
                efluente.FonteGeradora,
                "Fonte Geradora");

        response.TipoDestinacao =
            ObterDescricaoDominio(
                efluente.TipoDestinacao,
                "Tipo Destinacao");

        response.TipoVeiculo =
            ObterDescricaoDominio(
                efluente.TipoVeiculo,
                "Tipo Veiculo");

        response.Proprietario =
            ObterDescricaoDominio(
                efluente.Proprietario,
                "Proprietario");

        response.NomeAreaGestoraCptm =
            ObterDescricaoDominio(
                efluente.NomeAreaGestoraCptm,
                "Nome Área Gestora CPTM");

        return response;
    }

    public async Task<IEnumerable<EfluenteResponse>>
        GetAllAsync()
    {
        var efluentes =
            await _repository.GetAllAsync();

        var responses =
            new List<EfluenteResponse>();

        foreach (var efluente in efluentes)
        {
            var response =
                _mapper.Map<EfluenteResponse>(
                    efluente);

            response.SiglaDepartamentoMeioAmbiente =
                ObterDescricaoDominio(
                    efluente.SiglaDepartamentoMeioAmbiente,
                    "Sigla Departamento Meio Ambiente");

            response.StatusDesvioAmbiental =
                ObterDescricaoDominio(
                    efluente.StatusDesvioAmbiental,
                    "Status Desvio Ambiental");

            response.StatusRegistroBd =
                ObterDescricaoDominio(
                    efluente.StatusRegistroBd,
                    "Status Registro BD");

            response.Municipio =
                ObterDescricaoDominio(
                    efluente.Municipio,
                    "Municipio");

            response.LinhaCptm =
                ObterDescricaoDominio(
                    efluente.LinhaCptm,
                    "Linha CPTM");

            response.ViaCptm =
                ObterDescricaoDominio(
                    efluente.ViaCptm,
                    "Via CPTM");

            response.TrechoSentidoCptm =
                ObterDescricaoDominio(
                    efluente.TrechoSentidoCptm,
                    "Trecho e Sentido CPTM");

            response.EstacaoCptm =
                ObterDescricaoDominio(
                    efluente.EstacaoCptm,
                    "Estacao CPTM");

            response.NaturezaPga =
                ObterDescricaoDominio(
                    efluente.NaturezaPga,
                    "Natureza do PGA");

            response.TipoAtividadeListada =
                ObterDescricaoDominio(
                    efluente.TipoAtividadeListada,
                    "Tipo Atividade Listada");

            response.TipoDraListado =
                ObterDescricaoDominio(
                    efluente.TipoDraListado,
                    "Tipo DRA Listado");

            response.TipoAtividadeCptm =
                ObterDescricaoDominio(
                    efluente.TipoAtividadeCptm,
                    "Tipo Atividade CPTM");

            response.NomeLocalAtividade =
                ObterDescricaoDominio(
                    efluente.NomeLocalAtividade,
                    "Nome Local Atividade");

            response.OrigemEfluente =
                ObterDescricaoDominio(
                    efluente.OrigemEfluente,
                    "Origem Efluente");

            response.FonteGeradora =
                ObterDescricaoDominio(
                    efluente.FonteGeradora,
                    "Fonte Geradora");

            response.TipoDestinacao =
                ObterDescricaoDominio(
                    efluente.TipoDestinacao,
                    "Tipo Destinacao");

            response.TipoVeiculo =
                ObterDescricaoDominio(
                    efluente.TipoVeiculo,
                    "Tipo Veiculo");

            response.Proprietario =
                ObterDescricaoDominio(
                    efluente.Proprietario,
                    "Proprietario");

            response.NomeAreaGestoraCptm =
                ObterDescricaoDominio(
                    efluente.NomeAreaGestoraCptm,
                    "Nome Área Gestora CPTM");

            responses.Add(response);
        }

        return responses;
    }

    public async Task<EfluenteResponse>
        CreateAsync(
            CreateEfluenteRequest request)
    {

        await ValidarDominiosAsync(request);

        var data =
            _mapper.Map<EfluenteData>(
                request);

        var efluente =
            new Efluente(data);

        await _repository.AddAsync(
            efluente);

        await _repository.SaveChangesAsync();

        return _mapper.Map<EfluenteResponse>(
            efluente);
    }

    public async Task UpdateAsync(
        string codigoMeioAmbienteCptm,
        UpdateEfluenteRequest request)
    {
        var efluente =
            await GetEntityAsync(
                codigoMeioAmbienteCptm);

        var data =
            _mapper.Map<EfluenteData>(
                request);

        await ValidarDominiosAsync(request);

        efluente.Update(data);

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        string codigoMeioAmbienteCptm)
    {
        var efluente =
            await GetEntityAsync(
                codigoMeioAmbienteCptm);

        efluente.Delete();

        await _repository.SaveChangesAsync();
    }

    private async Task<Efluente>
        GetEntityAsync(
            string codigoMeioAmbienteCptm)
    {
        var efluente =
            await _repository.GetByIdAsync(
                codigoMeioAmbienteCptm);

        if (efluente is null)
        {
            throw new NotFoundException(
                $"Efluente '{codigoMeioAmbienteCptm}' não encontrado.");
        }

        return efluente;
    }

    private Task ValidarDominioAsync(
         int? codigo,
         string dominio)
    {
        if (!codigo.HasValue)
            return Task.CompletedTask;

        var existe =
            _dominioCacheService
                .Exists(
                    dominio,
                    codigo.Value);

        if (!existe)
        {
            throw new Exception(
                $"{dominio} inválido.");
        }

        return Task.CompletedTask;
    }

    private async Task ValidarDominiosAsync(
        CreateEfluenteRequest request)
    {
        await ValidarDominioAsync(
            request.SiglaDepartamentoMeioAmbiente,
            "Sigla Departamento Meio Ambiente");

        await ValidarDominioAsync(
            request.StatusDesvioAmbiental,
            "Status Desvio Ambiental");

        await ValidarDominioAsync(
            request.StatusRegistroBd,
            "Status Registro BD");

        await ValidarDominioAsync(
            request.Municipio,
            "Municipio");

        await ValidarDominioAsync(
            request.LinhaCptm,
            "Linha CPTM");

        await ValidarDominioAsync(
            request.ViaCptm,
            "Via CPTM");

        await ValidarDominioAsync(
            request.TrechoSentidoCptm,
            "Trecho e Sentido CPTM");

        await ValidarDominioAsync(
            request.EstacaoCptm,
            "Estacao CPTM");

        await ValidarDominioAsync(
            request.NaturezaPga,
            "Natureza do PGA");

        await ValidarDominioAsync(
            request.TipoAtividadeListada,
            "Tipo Atividade Listada");

        await ValidarDominioAsync(
            request.TipoDraListado,
            "Tipo DRA Listado");

        await ValidarDominioAsync(
            request.TipoAtividadeCptm,
            "Tipo Atividade CPTM");

        await ValidarDominioAsync(
            request.NomeLocalAtividade,
            "Nome Local Atividade");

        await ValidarDominioAsync(
            request.OrigemEfluente,
            "Origem Efluente");

        await ValidarDominioAsync(
            request.FonteGeradora,
            "Fonte Geradora");

        await ValidarDominioAsync(
            request.TipoDestinacao,
            "Tipo Destinacao");

        await ValidarDominioAsync(
            request.TipoVeiculo,
            "Tipo Veiculo");

        await ValidarDominioAsync(
            request.OfereceRiscoSistemaCptm,
            "Sim Nao");

        await ValidarDominioAsync(
           request.Proprietario,
           "Proprietario");

        await ValidarDominioAsync(
            request.NomeAreaGestoraCptm,
            "Nome Área Gestora CPTM");
    }

    private async Task ValidarDominiosAsync(
        UpdateEfluenteRequest request)
    {
        await ValidarDominioAsync(
            request.SiglaDepartamentoMeioAmbiente,
            "Sigla Departamento Meio Ambiente");

        await ValidarDominioAsync(
            request.StatusDesvioAmbiental,
            "Status Desvio Ambiental");

        await ValidarDominioAsync(
            request.StatusRegistroBd,
            "Status Registro BD");

        await ValidarDominioAsync(
            request.Municipio,
            "Municipio");

        await ValidarDominioAsync(
            request.LinhaCptm,
            "Linha CPTM");

        await ValidarDominioAsync(
            request.ViaCptm,
            "Via CPTM");

        await ValidarDominioAsync(
            request.TrechoSentidoCptm,
            "Trecho e Sentido CPTM");

        await ValidarDominioAsync(
            request.EstacaoCptm,
            "Estacao CPTM");

        await ValidarDominioAsync(
            request.NaturezaPga,
            "Natureza do PGA");

        await ValidarDominioAsync(
            request.TipoAtividadeListada,
            "Tipo Atividade Listada");

        await ValidarDominioAsync(
            request.TipoDraListado,
            "Tipo DRA Listado");

        await ValidarDominioAsync(
            request.TipoAtividadeCptm,
            "Tipo Atividade CPTM");

        await ValidarDominioAsync(
            request.NomeLocalAtividade,
            "Nome Local Atividade");

        await ValidarDominioAsync(
            request.OrigemEfluente,
            "Origem Efluente");

        await ValidarDominioAsync(
            request.FonteGeradora,
            "Fonte Geradora");

        await ValidarDominioAsync(
            request.TipoDestinacao,
            "Tipo Destinacao");

        await ValidarDominioAsync(
            request.TipoVeiculo,
            "Tipo Veiculo");

        await ValidarDominioAsync(
            request.OfereceRiscoSistemaCptm,
            "Sim Nao");

        await ValidarDominioAsync(
            request.Proprietario,
            "Proprietario");

        await ValidarDominioAsync(
            request.NomeAreaGestoraCptm,
            "Nome Área Gestora CPTM");
    }

    private string? ObterDescricaoDominio(
         int? codigo,
         string dominio)
    {
        return _dominioCacheService
            .GetDescricao(
                dominio,
                codigo);
    }
}