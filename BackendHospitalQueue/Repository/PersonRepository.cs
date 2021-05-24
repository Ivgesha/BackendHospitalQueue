using BackendHospitalQueue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHospitalQueue.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonsContext _personsContext;
        public PersonRepository(PersonsContext personsContext) {
            _personsContext = personsContext;
        }

        public async Task<Person> Create(Person person)             // insert 
        {
            _personsContext.Persons.Add(person);
            await _personsContext.SaveChangesAsync();
            return person;

        }

        public async Task Delete(int id)                             // delete 
        {
            var personToDelete = await _personsContext.Persons.FindAsync(id);
            _personsContext.Persons.Remove(personToDelete);
            await _personsContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Person>> Get()                // select * 
        {
            return await _personsContext.Persons.ToListAsync();
        }

        public async Task<Person> Get(int id)                       // get spesific person
        {
            return await _personsContext.Persons.FindAsync(id);
        }

        public async Task Update(Person person)
        {
            _personsContext.Entry(person).State = EntityState.Modified;
            await _personsContext.SaveChangesAsync();
         }
    }
}
