using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asteria.Models.DTO
{
    public class RecordsDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public int Clientid { get; set; }
        [Required]
        public string SpecName { get; set; }
        [Required]
        public int SpecId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public string TypeWork { get; set; }
        [Required]
        public int? Price { get; set; }

    }
}
