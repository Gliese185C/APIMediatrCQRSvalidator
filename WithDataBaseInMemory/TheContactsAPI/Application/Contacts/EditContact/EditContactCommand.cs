using DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.EditContact
{
    public class EditContactCommand : IRequest
    {
        public EditContactCommand(Guid id, UpdateContactDTO data)
        {
            Id = id;
            Data = data;
        }
        public Guid Id { get; set; }
        public UpdateContactDTO Data { get; set; }
    }
}
