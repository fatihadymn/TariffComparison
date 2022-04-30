using FluentValidation;
using TariffComparison.Items.Queries;

namespace TariffComparison.Items.Validators
{
    public class GetTariffsRequestValidator : AbstractValidator<GetTariffsRequest>
    {
        public GetTariffsRequestValidator()
        {
            RuleFor(x => x.Consumption).GreaterThan(0)
                                       .WithMessage("Consumption should be greater than zero");
        }
    }
}
