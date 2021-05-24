using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHospitalQueue.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int PersonsId { get; set; }
        public int QueueNumber  { get; set; }
        public bool isInQueue { get; set;  }
        public DateTime Created_on  { get; set; }
        public DateTime Finished_on  { get; set; }
    }
}
