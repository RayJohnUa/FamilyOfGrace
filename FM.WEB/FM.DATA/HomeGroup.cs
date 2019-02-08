using System;
using System.Collections.Generic;
using System.Text;

namespace FM.DATA
{
    public class HomeGroup : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<GroupSession> GroupSession { get; set; }
    }
}
