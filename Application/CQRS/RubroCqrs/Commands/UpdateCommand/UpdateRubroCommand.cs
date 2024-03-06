
using Application.Common.Interfaces;
using Application.Commons;
using Application.CQRS.RubroCqrs.Commands.RubroCreateCommand;
using Application.Mappings;
using AutoMapper;
using buen_sabor.api.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.RubroCqrs.Commands.UpdatedCommand;

public class UpdateRubroCommand : IRequestCustom<UpdateRubroCommand, Guid>, IMapFrom<Rubro>
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public void AssignId(Guid id) => this.Id = id;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateRubroCommand, Rubro>();
}

public class UpdateRubroHandler : IRequestHandler<UpdateRubroCommand, ResultModel<UpdateRubroCommand, Guid>>
{
    private readonly IMapper _mapper;
    private readonly IAppDBContext _context;
    private readonly IRubroRepository _repository;

    public UpdateRubroHandler(IMapper mapper, IRubroRepository repository, IAppDBContext context)
    {
        _mapper = mapper;
        _repository = repository;
        _context = context;
    }

    public async Task<ResultModel<UpdateRubroCommand, Guid>> Handle(UpdateRubroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id);

        var entityToUpdate = _mapper.Map<Rubro>(request);
        entityToUpdate.Id = entity.Id;
        entityToUpdate.Creado = entity.Creado;
        entityToUpdate.Habilitado = entity.Habilitado;
        entity = entityToUpdate;

        _context.Rubro.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        //_repository.Update(entity);

        return ResultModel<UpdateRubroCommand, Guid>.Transform(request, entityToUpdate.Id);
    }
}
