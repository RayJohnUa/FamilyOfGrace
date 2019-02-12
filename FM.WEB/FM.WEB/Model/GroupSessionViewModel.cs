using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FM.WEB.Model
{
    public class GroupSessionViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int HomeGroupId { get; set; }

        public ICollection<PersonViewModel> Persons { get; set; }
    }
}
