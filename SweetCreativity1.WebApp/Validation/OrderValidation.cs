using FluentValidation;
using SweetCreativity1.Core.Entities;

namespace SweetCreativity1.WebApp.Validation
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            //RuleFor(x => x.NameOrder)
            //    .NotEmpty()
            //    .MinimumLength(2)
            //    .Matches(@"[A-ZА-Я].*").WithMessage("{PropertyName} must start with an uppercase letter.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(x => x.CustomerNumber)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
