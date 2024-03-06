
using Application.Commons;
using Application.Exceptions;
using AutoMapper;
using buen_sabor.api.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.RubroCqrs.Commands.DeleteCommand;

public class DeleteRubroCommand : IRequestCustom<DeleteRubroCommand, Guid>
{
    public Guid Id { get; set; }
    public void AssignId(Guid id) => this.Id = id; 
}

public class DeleteRubroHandler : IRequestHandler<DeleteRubroCommand, ResultModel<DeleteRubroCommand, Guid>>
{
    private readonly IMapper _mapper;
    private readonly IRubroRepository _repository;

    public DeleteRubroHandler(IMapper mapper, IRubroRepository repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultModel<DeleteRubroCommand, Guid>> Handle(DeleteRubroCommand request, CancellationToken cancellationToken)
    {
        var rubro = await _repository.GetById(request.Id);
        if (rubro == null) throw new NotFoundException(nameof(Rubro), request.Id);
        if (rubro.Habilitado == false) return ResultModel<DeleteRubroCommand, Guid>.Transform(request, rubro.Id, true, $"Entidad: {nameof(Rubro)}, ID:[{request.Id}] ya se encuentra deshabilitada.");

        _repository.Delete(rubro);
        return ResultModel<DeleteRubroCommand, Guid>.Transform(request, rubro.Id);
    }
}
