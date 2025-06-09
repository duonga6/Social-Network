using FluentValidation;
using SocialNetwork.Application.Features.Users.Commands;

namespace SocialNetwork.Application.Features.Users.Validators
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First Name is required.");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last Name is required.");

            RuleFor(u => u.EmailAddress)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email address invalid.");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password length must be at least 8.")
                .MaximumLength(16).WithMessage("Password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.");

            RuleFor(u => u.DateOfBirth)
                .NotNull().WithMessage("Date of birth is required");

            RuleFor(u => u.Gender)
                .NotNull().WithMessage("Gender is required");
        }
    }
}
