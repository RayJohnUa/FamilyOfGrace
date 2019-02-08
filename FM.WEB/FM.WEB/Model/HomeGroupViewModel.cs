using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FM.DATA;

namespace FM.WEB.Model
{
    public class HomeGroupViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<PersonViewModel> People { get; set; }
        public ICollection<GroupSessionViewModel> GroupSession { get; set; }
    }
}
