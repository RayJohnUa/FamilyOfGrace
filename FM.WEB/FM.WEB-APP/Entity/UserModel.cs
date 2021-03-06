﻿using System.ComponentModel.DataAnnotations;

namespace FM.WEB-APP.Entity
{
    public class UserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
