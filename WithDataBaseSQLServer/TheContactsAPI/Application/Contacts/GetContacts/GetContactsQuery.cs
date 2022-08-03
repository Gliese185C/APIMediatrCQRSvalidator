using DataTransferObjects;
using MediatR;
using Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.GetContacts
{
    public class GetContactsQuery : IRequest<List<GetContactDTO>>
    {
        public GetContactsQuery()
        {

        }
    }
}
