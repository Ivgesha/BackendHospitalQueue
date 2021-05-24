using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHospitalQueue.Models
{
    public class PersonsContext : DbContext 
    {
        public PersonsContext(DbContextOptions<PersonsContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }              // represending collection 
    }
}
