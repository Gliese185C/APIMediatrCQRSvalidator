

using DataTransferObjects;
using FluentValidation;

namespace Application.Contacts.AddContact
{
    public class AddContactValidator : AbstractValidator<AddContactDTO>
    {
        public AddContactValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Address).NotNull().MaximumLength(30);
            RuleFor(u => u.FullName).NotNull().NotEmpty();
            RuleFor(u => u.Address)
                .Must(a => a?.ToLower().Contains("street") == true)
                .WithMessage("Address must containt street");
            RuleFor(u => u.Phone).NotNull().NotEmpty();
        }
    }
}
