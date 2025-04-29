using Application.Models.SubRequestModel;
using FluentValidation;

namespace Application.Validator
{
    public class RegisterRequestValidator : AbstractValidator<RequestUser>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}
