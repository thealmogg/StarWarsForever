using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWarsForever.Controllers.Resources;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Controllers
{
    [Route("/api/contacts")]
    public class ContactsController : Controller
    {
        public IUnitOfWork unitOfWork { get; }
        public IContactRepo contactRepo { get; }
        public IMapper mapper { get; }
        public ContactsController(IMapper mapper, IUnitOfWork unitOfWork, IContactRepo contactRepo)
        {
            this.mapper = mapper;
            this.contactRepo = contactRepo;
            this.unitOfWork = unitOfWork;

        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactResource contactResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contact = mapper.Map<ContactResource, Contact>(contactResource);
            contactRepo.Add(contact);
            await unitOfWork.CompleteAsync();

            contact = await contactRepo.GetContact(contact.Id);
            return Ok(mapper.Map<Contact, ContactResource>(contact));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactResource contactResource)
        {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var contact = await contactRepo.GetContact(id);
            if(contact == null) {
                return NotFound();
            }
            mapper.Map<ContactResource, Contact>(contactResource, contact);

            await unitOfWork.CompleteAsync();

            contact = await contactRepo.GetContact(contact.Id);
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact =  await contactRepo.GetContact(id, includeRelated: false);
            if(contact == null) {
                return NotFound();
            }
            contactRepo.Remove(contact);

            await unitOfWork.CompleteAsync();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await contactRepo.GetContact(id);
            if(contact == null) {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var contacts = await contactRepo.GetContacts();

            return contacts;
        }
    }
}