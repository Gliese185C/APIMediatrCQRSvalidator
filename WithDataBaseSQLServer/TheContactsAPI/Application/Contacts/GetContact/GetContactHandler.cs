using DataTransferObjects;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, GetContactDTO>
    {
        private readonly ContactsAPIDbContext _contactsAPIDbContext;

        public GetContactHandler(ContactsAPIDbContext contactsAPIDbContext)
        {
            _contactsAPIDbContext = contactsAPIDbContext;
        }

        public async Task<GetContactDTO> Handle(GetContactQuery request, CancellationToken cancellation)
        {
            var productToView = _contactsAPIDbContext.Contacts.FirstOrDefault(x => x.Id == request.Id);
            if (productToView != null)
            {
                return new GetContactDTO
                {
                    Address = productToView.Address,
                    Phone = productToView.Phone,
                    FullName = productToView.FullName,
                    Email = productToView.Email
                };
            }
            else return new GetContactDTO { };
        }
    }
}
