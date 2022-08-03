using MediatR;


namespace Application.Contacts.DeleteContact
{
    public class DeleteConctactCommand : IRequest
    {
        public DeleteConctactCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
