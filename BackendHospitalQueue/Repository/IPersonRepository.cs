using BackendHospitalQueue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHospitalQueue.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> Get();            // will return list of persons: select * from table.

        Task<Person> Get(int id);                   // return single person. select * from table where id = @id

        Task<Person> Create(Person person);         // insert into table new person.

        Task Update(Person person);                 // update table set (person = @person).

        Task Delete(int id);                        // delete person.


    }
}
