using AutoMapper;

public class EfluenteMapper : Profile
{
    public EfluenteMapper()
    {
        CreateMap<CreateEfluenteRequest, EfluenteData>();

        CreateMap<UpdateEfluenteRequest, EfluenteData>();

        CreateMap<Efluente, EfluenteResponse>()

         .ForMember(dest => dest.Municipio, opt => opt.Ignore())
         .ForMember(dest => dest.LinhaCptm, opt => opt.Ignore())
         .ForMember(dest => dest.ViaCptm, opt => opt.Ignore())
         .ForMember(dest => dest.TrechoSentidoCptm, opt => opt.Ignore())
         .ForMember(dest => dest.EstacaoCptm, opt => opt.Ignore())
         .ForMember(dest => dest.SiglaDepartamentoMeioAmbiente, opt => opt.Ignore())
         .ForMember(dest => dest.StatusDesvioAmbiental, opt => opt.Ignore())
         .ForMember(dest => dest.StatusRegistroBd, opt => opt.Ignore())
         .ForMember(dest => dest.NaturezaPga, opt => opt.Ignore())
         .ForMember(dest => dest.TipoAtividadeListada, opt => opt.Ignore())
         .ForMember(dest => dest.TipoDraListado, opt => opt.Ignore())
         .ForMember(dest => dest.TipoAtividadeCptm, opt => opt.Ignore())
         .ForMember(dest => dest.NomeLocalAtividade, opt => opt.Ignore())
         .ForMember(dest => dest.OrigemEfluente, opt => opt.Ignore())
         .ForMember(dest => dest.FonteGeradora, opt => opt.Ignore())
         .ForMember(dest => dest.TipoDestinacao, opt => opt.Ignore())
         .ForMember(dest => dest.TipoVeiculo, opt => opt.Ignore())
         .ForMember(dest => dest.OfereceRiscoSistemaCptm, opt => opt.Ignore())
         .ForMember(dest => dest.Proprietario, opt => opt.Ignore())
         .ForMember(dest => dest.NomeAreaGestoraCptm, opt => opt.Ignore());
    }
}