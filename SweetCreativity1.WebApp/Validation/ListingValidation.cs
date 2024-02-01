using FluentValidation;
using SweetCreativity1.Core.Entities;

namespace SweetCreativity1.WebApp.Validation
{
    public class ListingValidation : AbstractValidator<Listing>
    {
        public ListingValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(2)
               .Matches(@"[A-ZА-Я].*").WithMessage("{PropertyName} must start with an uppercase letter.");


            RuleFor(x => x.Description)
                   .NotEmpty()
                   .MinimumLength(2)
                   .MaximumLength(500);


            RuleFor(x => x.Product)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100); 

            RuleFor(x => x.Location)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100)
                .Matches(@"[A-ZА-Я].*").WithMessage("{PropertyName} must start with an uppercase letter.");


            RuleFor(x => x.Price)
                .GreaterThan(0); 

            RuleFor(x => x.Weight)
                .GreaterThan(0);

            RuleFor(x => x.CoverFile)
                .NotEmpty().WithMessage("Please upload a cover file.")
                .Must(IsJpg).WithMessage("Invalid file format. Only JPG files are allowed.");
        }

        private bool IsJpg(IFormFile file)
        {
            return file != null && Path.GetExtension(file.FileName).Equals(".jpg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
