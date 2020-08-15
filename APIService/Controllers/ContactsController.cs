using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using APIService.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetContacts();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            var result= _contactRepository.GetContact(id);
            if(result==null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact model)
        {
            if(model==null)
            {
                return new BadRequestResult();
            }
            var contact= _contactRepository.Add(model);
            return CreatedAtAction(nameof(Get),new { id=model.Id}, contact) ;
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact model)
        {
            if(model!=null)
            {
                var contact = _contactRepository.Update(id, model);
                return CreatedAtAction(nameof(Get), new { id=model.Id}, contact);
            }
            return new BadRequestResult();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contactRepository.Delete(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
