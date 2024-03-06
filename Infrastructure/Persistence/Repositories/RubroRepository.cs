
using Application.Common.Interfaces;
using buen_sabor.api.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RubroRepository : IRubroRepository
{
    private readonly IAppDBContext _context;

    public RubroRepository(IAppDBContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

    public void Save(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken))
    {
        _context.Rubro.Add(rubro);
        _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task Update(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken))
    {
        _context.Rubro.Update(rubro);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Rubro> GetById(Guid id) => await _context.Rubro.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();

    public async Task Delete(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken))
    {
        _context.Rubro.Remove(rubro);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
