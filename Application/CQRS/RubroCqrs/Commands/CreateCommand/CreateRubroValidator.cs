
using Application.CQRS.RubroCqrs.Commands.RubroCreateCommand;
using FluentValidation;

namespace Application.CQRS.RubroCqrs.Commands.CreateCommand;

public class CreateRubroValidator : AbstractValidator<CreateRubroCommand>
{
    public CreateRubroValidator()
    {
        RuleFor(r => r.Nombre).NotNull().NotEmpty().WithMessage("El campo nombre no puede estar vacío o nulo.");
    }
}
