using System;
using System.Collections.Generic;
using System.Text;

namespace FM.DATA
{
    public class MailingPerson : BaseEntity
    {
        public int MailingId { get; set; }
        public virtual Mailing Mailing { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
