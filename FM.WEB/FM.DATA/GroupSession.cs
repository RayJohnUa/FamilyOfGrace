using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FM.DATA
{
    public class GroupSession : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        public virtual HomeGroup HomeGroup { get; set; }
        public int HomeGroupId { get; set; }
        public virtual ICollection<GroupSesionPerson> GroupSesionPersons { get; set; }
    }
}
