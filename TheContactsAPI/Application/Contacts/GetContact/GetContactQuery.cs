using DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.GetContact
{
    public class GetContactQuery : IRequest<GetContactDTO>
    {
        public GetContactQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
