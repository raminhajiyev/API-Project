using FluentValidation;
using WebAPI.DTOs.MessageDTO;
using WebAPI.Entities;

namespace WebAPI.ValidationRules
{
    public class MessageValidator : AbstractValidator<CreateMessageDTO>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Fullname is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.")
                .MaximumLength(200).WithMessage("Max 200 character");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.")
                .MaximumLength(500).WithMessage("Max 500 character");

        }
    }
}
