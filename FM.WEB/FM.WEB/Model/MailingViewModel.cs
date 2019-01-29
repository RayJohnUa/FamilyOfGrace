using FM.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FM.WEB.Model
{
    public class MailingViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }

        public List<Person> Persons { get; set; }
    }
}
