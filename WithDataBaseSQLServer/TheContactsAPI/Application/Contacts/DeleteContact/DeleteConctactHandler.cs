using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.DeleteContact
{
    public class DeleteConctactHandler : IRequestHandler<DeleteConctactCommand>
    {
        private readonly ContactsAPIDbContext _contactsAPIDbContext;

        public DeleteConctactHandler(ContactsAPIDbContext contactsAPIDbContext)
        {
            _contactsAPIDbContext = contactsAPIDbContext;
        }

        public async Task<Unit> Handle(DeleteConctactCommand request, CancellationToken cancellation)
        {
            var productToDelete = _contactsAPIDbContext.Contacts.FirstOrDefault(c=>c.Id==request.Id);
            if (productToDelete != null)
            {
                _contactsAPIDbContext.Contacts.Remove(productToDelete);
                await _contactsAPIDbContext.SaveChangesAsync();
            }
            return Unit.Value;

        }

    }
}
