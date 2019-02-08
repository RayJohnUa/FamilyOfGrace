using System;
using System.Collections.Generic;
using System.Text;

namespace FM.DATA
{
    public class GroupSesionPerson : BaseEntity
    {
        public virtual GroupSession GroupSession { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public int GroupSessionId { get; set; }
    }
}
