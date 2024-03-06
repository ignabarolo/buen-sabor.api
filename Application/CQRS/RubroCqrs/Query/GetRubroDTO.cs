
using Application.Mappings;
using AutoMapper;
using buen_sabor.api.Entities;
using Domain.Entities;

namespace Application.CQRS.RubroCqrs.Query;

public class GetRubroDTO : BaseEntity, IMapFrom<Rubro>
{
    public string Nombre { get; set; }

    public virtual ICollection<Manufacturado> Manufacturados { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<Rubro, GetRubroDTO>();
}

