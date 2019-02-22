using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FM.DATA
{
    public class Prayer : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }

        public string Phone { get; set; }
        [Required]
        public StatusPrayer Status { get; set; }
    }

    public enum StatusPrayer
    {
        InProgress = 0,
        Completed = 1
    }
}
