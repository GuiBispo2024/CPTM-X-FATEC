using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;
using Backend.Domain;

namespace Backend.Infrastructure.Repositories;

public class MunicipioRepository : IMunicipioRepository
{
    private readonly AppDbContext _context;

    // Recebemos o nosso "Mapa" do banco (AppDbContext) através do construtor
    public MunicipioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Municipio>> ObterTodosAsync()
    {
        // Vai na tabela DOMINIO_MUNICIPIO, busca tudo de forma rápida e assíncrona
        return await _context.Municipios.ToListAsync();
    }
}