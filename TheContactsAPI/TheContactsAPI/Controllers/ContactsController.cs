using Application.Contacts.AddContact;
using Application.Contacts.DeleteContact;
using Application.Contacts.EditContact;
using Application.Contacts.GetContact;
using Application.Contacts.GetContacts;
using DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entity;

namespace TheContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            this._mediator = mediator;

        }
        //[HttpGet]
        //public async Task<IActionResult> GetContacts()
        //{
        //    var result = await _mediator.Send();
        //    return Ok(await dbContext.Contacts.ToListAsync());
        //
        //}

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactDTO addcontactdto)
        {

            return Ok(await _mediator.Send(new AddContactCommand(addcontactdto)));
        }

        [HttpDelete]
        [Route("id")]

        public async Task<Unit> DeleteContact(Guid id)
        {
            Console.Write(id);
            return (await _mediator.Send(new DeleteConctactCommand(id)));
        }

        [HttpPut]
        [Route("id")]

        public async Task<IActionResult> UpdateContact(Guid id,UpdateContactDTO getcontactdto)
        {
            return Ok(await _mediator.Send(new EditContactCommand(id, getcontactdto)));
        }

        [HttpGet]
        [Route("id")]

        public async Task<IActionResult> GetContact(Guid id)
        {
            return Ok(await _mediator.Send(new GetContactQuery(id)));
        }

        [HttpGet]

        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _mediator.Send(new GetContactsQuery()));
        }
    }
}
