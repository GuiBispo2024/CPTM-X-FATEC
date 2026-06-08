using AutoMapper;

public class DominioMapper : Profile
{
    public DominioMapper()
    {
        CreateMap<Dominio, DominioResponse>();
    }
}