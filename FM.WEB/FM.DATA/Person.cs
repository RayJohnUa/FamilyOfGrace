using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FM.DATA
{
    public class Person : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Telephone { get; set; }

        public virtual ICollection<MailingPerson> MailingPerson { get; set; }
    }
}
