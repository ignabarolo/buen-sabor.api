using Application.Common.Interfaces;
using Application.Commons;
using Application.Mappings;
using AutoMapper;
using buen_sabor.api.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.RubroCqrs.Commands.RubroCreateCommand;

public class CreateRubroCommand : IRequestCustom<CreateRubroCommand, Guid>, IMapFrom<Rubro>
{
    public string Nombre { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateRubroCommand, Rubro>();
}

public class RubroCreateHandler : IRequestHandler<CreateRubroCommand, ResultModel<CreateRubroCommand, Guid>>
{
    private readonly IMapper _mapper;
    private readonly IRubroRepository _repository;

    public RubroCreateHandler(IAppDBContext context, IMapper mapper, IRubroRepository repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultModel<CreateRubroCommand, Guid>> Handle(CreateRubroCommand request, CancellationToken cancellationToken)
    {
        var rubro = _mapper.Map<Rubro>(request);
        _repository.Save(rubro);

        return ResultModel<CreateRubroCommand, Guid>.Transform(request, rubro.Id);
    }
}