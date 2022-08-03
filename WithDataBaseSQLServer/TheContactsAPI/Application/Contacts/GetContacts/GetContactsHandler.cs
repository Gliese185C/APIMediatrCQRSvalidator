using DataTransferObjects;
using MediatR;
using Persistence.Context;
using Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.GetContacts
{
    public class GetContactsHandler : IRequestHandler<GetContactsQuery, List<GetContactDTO>>
    {
        private readonly ContactsAPIDbContext _contactsAPIDbContext;

        public GetContactsHandler(ContactsAPIDbContext contactsAPIDbContext)
        {
            _contactsAPIDbContext = contactsAPIDbContext;
        }
        public async Task<List<GetContactDTO>> Handle(GetContactsQuery request,CancellationToken cancellation)
        {
            List<Contact> contacts = _contactsAPIDbContext.Contacts.ToList();
            List<GetContactDTO> contactsDTO = new List<GetContactDTO> { };
            foreach (Contact item in contacts)
            {
                contactsDTO.Add(new GetContactDTO
                {
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    FullName = item.FullName
                });
            }
            return contactsDTO;
        }

    }
}
