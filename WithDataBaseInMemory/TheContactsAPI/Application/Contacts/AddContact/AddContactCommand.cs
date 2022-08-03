using DataTransferObjects;
using MediatR;
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
