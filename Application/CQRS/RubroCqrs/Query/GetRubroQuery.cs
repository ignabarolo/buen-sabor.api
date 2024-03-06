
using Application.Common.Interfaces;
using Application.Commons;
using Application.Exceptions;
using Domain.Interfaces;
using AutoMapper;
using buen_sabor.api.Entities;
using MediatR;

namespace Application.CQRS.RubroCqrs.Query;

public class GetRubroQuery : IRequestCustom<GetRubroQuery, GetRubroDTO>
{
    public Guid Id { get; set; }

    public void AssignId(Guid id) => this.Id = id;
}

public class GetRubroHandler : IRequestHandler<GetRubroQuery, ResultModel<GetRubroQuery, GetRubroDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRubroRepository _repository;

    public GetRubroHandler(IMapper mapper, IRubroRepository repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultModel<GetRubroQuery, GetRubroDTO>> Handle(GetRubroQuery request, CancellationToken cancellationToken)
    {
        var rubro = await _repository.GetById(request.Id);
        if (rubro == null) throw new NotFoundException(nameof(Rubro), request.Id);

        var rubroDTO = _mapper.Map<GetRubroDTO>(rubro);
        return ResultModel<GetRubroQuery, GetRubroDTO>.Transform(request, rubroDTO);
    }
}

