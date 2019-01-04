using System.ComponentModel.DataAnnotations;

namespace FM.DATA
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
