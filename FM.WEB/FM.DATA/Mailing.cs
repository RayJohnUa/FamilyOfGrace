using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FM.DATA
{
    public class Mailing : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual ICollection<MailingPerson> MailingPerson { get; set; }
    }
}
