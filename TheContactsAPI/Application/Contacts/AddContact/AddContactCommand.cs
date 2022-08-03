using DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.AddContact
{
    public class AddContactCommand : IRequest<Guid>
    {
        public AddContactCommand(AddContactDTO data)
        {
            Data = data;
        }

        public AddContactDTO Data { get; set; }
    }
}
