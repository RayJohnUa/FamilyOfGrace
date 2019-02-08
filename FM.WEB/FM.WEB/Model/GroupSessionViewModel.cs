using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FM.WEB.Model
{
    public class GroupSessionViewModel
    {
        public int Id { get; set; }

        public HomeGroupViewModel HomeGroup { get; set; }
        public virtual ICollection<PersonViewModel> People { get; set; }
    }
}
