using BackendHospitalQueue.Models;
using BackendHospitalQueue.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHospitalQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonsController(IPersonRepository personRepository) {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPeople() {
            return await _personRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id) {
            return await _personRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Person>> postPerson([FromBody] Person person) {
            var newPerson = await _personRepository.Create(person);
            return CreatedAtAction(nameof(GetPeople), new { id = person.Id }, newPerson);
        }
        [HttpPut]
        public async Task<ActionResult> PutPerson(int id, [FromBody] Person person) {
            if (id != person.Id)
                return BadRequest();
            await _personRepository.Update(person);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) {
            var personToDelete = await _personRepository.Get(id);
            if (personToDelete == null)
                return NotFound();
            await _personRepository.Delete(personToDelete.Id);
            return NoContent();
        
        }

    }
}
