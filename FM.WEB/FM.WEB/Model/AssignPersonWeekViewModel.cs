using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FM.WEB.Model
{
    public class AssignPersonWeekViewModel
    {
        [Required]
        public int WeekId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public bool IsAssigne { get; set; }
    }
}
