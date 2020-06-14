using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Models
{
    public class Record
    {
        public Record()
        {
        }

        public Record(int id, int clientId, int specId, DateTime date, TimeSpan time, string typeWork, int? price)
        {
            Id = id;
            ClientId = clientId;
            SpecId = specId;
            Date = date;
            Time = time;
            TypeWork = typeWork;
            Price = price;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SpecId { get; set; }
        public DateTime Date {get;set ;}
        public TimeSpan Time { get; set; }
        public string TypeWork { get; set; }
        public int? Price { get; set; }
    }
}
