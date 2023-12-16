using FluentValidation;
using NeuronLogisticsServer.Application.ViewModels.Definitions;


namespace NeuronLogisticsServer.Application.Validators.Definitions
{
    public class CreateCargoContainerValidator : AbstractValidator<VM_Create_CargoContainer>
    {
        public CreateCargoContainerValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required.")
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("Enter min 2 max 50 characters.");

            RuleFor(p => p.Teu)
                .NotEmpty()
                .NotNull()
                .WithMessage("Teu is required.")
                .Must(t => t >= 0)
                .WithMessage("Can not be negative");
        }
    }
}