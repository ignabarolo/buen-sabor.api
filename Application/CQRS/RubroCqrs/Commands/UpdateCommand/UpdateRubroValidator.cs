using Application.CQRS.RubroCqrs.Commands.RubroCreateCommand;
using Application.CQRS.RubroCqrs.Commands.UpdatedCommand;
using FluentValidation;

namespace Application.CQRS.RubroCqrs.Commands.UpdateCommand;

public class UpdateRubroValidator : AbstractValidator<UpdateRubroCommand>
{
    public UpdateRubroValidator()
    {
        RuleFor(r => r.Nombre).NotNull().NotEmpty().WithMessage("El campo nombre no puede estar vacío o nulo.");
    }
}
