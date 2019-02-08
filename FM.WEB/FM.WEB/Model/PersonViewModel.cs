using System.ComponentModel.DataAnnotations;

namespace FM.WEB.Model
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Telephone { get; set; }
    }
}
