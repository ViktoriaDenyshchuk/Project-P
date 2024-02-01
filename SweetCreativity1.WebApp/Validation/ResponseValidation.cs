using FluentValidation;
using SweetCreativity1.Core.Entities;

namespace SweetCreativity1.WebApp.Validation
{
    public class ResponseValidation : AbstractValidator<Response>
    {
        public ResponseValidation()
        {
            RuleFor(x => x.TextResponse)
                .NotEmpty()
                .MinimumLength(2);
        }    
    }
}
