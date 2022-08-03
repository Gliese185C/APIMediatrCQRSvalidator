using MediatR;
using Persistence.Context;
using Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.AddContact
{
    public class AddContactHandler : IRequestHandler<AddContactCommand,Guid>
    {
        private readonly ContactsAPIDbContext _contactsAPIDbContext;

        public AddContactHandler(ContactsAPIDbContext contactsAPIDbContext)
        {
            _contactsAPIDbContext = contactsAPIDbContext;
        }

        public async Task<Guid> Handle(AddContactCommand request, CancellationToken cancellation) 
        {
            var productToAdd = new Contact
            {
                Id = new Guid(),
                FullName = request.Data.FullName,
                Email = request.Data.Email,
                Phone = request.Data.Phone,
                Address = request.Data.Address
            };
            _contactsAPIDbContext.Contacts.AddAsync(productToAdd);
            _contactsAPIDbContext.SaveChangesAsync();
            return productToAdd.Id;
        }

    }
}
