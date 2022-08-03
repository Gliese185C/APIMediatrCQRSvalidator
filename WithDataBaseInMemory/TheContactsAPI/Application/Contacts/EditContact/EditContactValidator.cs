using DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.EditContact
{
    public class EditContactValidator : AbstractValidator<UpdateContactDTO>
    {
        public EditContactValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Address).NotNull().MaximumLength(30);
            RuleFor(u => u.FullName).NotNull().NotEmpty();
            RuleFor(u => u.Address)
                .Must(a => a?.ToLower().Contains("street") == true)
                .WithMessage("Address must contain street");
            RuleFor(u => u.Phone).NotNull().NotEmpty();
        }
    }
}
