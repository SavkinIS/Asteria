using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Models
{
    public class TimeSheets
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SpecID { get; set; }

        /// Время для записи
        public int T9m00 { get; set; }
        public int T9m30 { get; set; }

        public int T10m00 { get; set; }
        public int T10m30 { get; set; }

        public int T11m00 { get; set; }
        public int T11m30 { get; set; }

        public int T12m00 { get; set; }
        public int T12m30 { get; set; }

        public int T13m00 { get; set; }
        public int T13m30 { get; set; }

        public int T14m00 { get; set; }
        public int T14m30 { get; set; }

        public int T15m00 { get; set; }
        public int T15m30 { get; set; }

        public int T16m00 { get; set; }
        public int T16m30 { get; set; }

        public int T17m00 { get; set; }
        public int T17m30 { get; set; }

        public int T18m00 { get; set; }
        public int T18m30 { get; set; }

        public int T19m00 { get; set; }
        public int T19m30 { get; set; }

        
    }
}
