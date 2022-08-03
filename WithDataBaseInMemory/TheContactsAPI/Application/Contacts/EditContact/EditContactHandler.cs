using DataTransferObjects;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.EditContact
{
    public class EditContactHandler : IRequestHandler<EditContactCommand>
    {
        private readonly ContactsAPIDbContext _contactsAPIDbContext;

        public EditContactHandler(ContactsAPIDbContext contactsAPIDbContext)
        {
            _contactsAPIDbContext = contactsAPIDbContext;
        }

        public async Task<Unit> Handle(EditContactCommand request, CancellationToken cancellation)
        {
            var productToUpdate = _contactsAPIDbContext.Contacts.FirstOrDefault(c => c.Id == request.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Email = request.Data.Email;
                productToUpdate.Phone = request.Data.Phone;
                productToUpdate.Address = request.Data.Address;
                productToUpdate.FullName = request.Data.FullName;
                await _contactsAPIDbContext.SaveChangesAsync();
            }
                
            return Unit.Value;

        }
    }

  
}
