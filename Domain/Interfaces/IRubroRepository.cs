using buen_sabor.api.Entities;

namespace Domain.Interfaces;

public interface IRubroRepository
{
    public void Save(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken));
    public Task Update(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken));
    public Task<Rubro> GetById(Guid id);
    public Task Delete(Rubro rubro, CancellationToken cancellationToken = default(CancellationToken));
}
