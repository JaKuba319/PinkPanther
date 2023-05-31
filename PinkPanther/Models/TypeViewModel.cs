using System.ComponentModel.DataAnnotations;

namespace PinkPanther.Models
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string TypeName { get; set; }
    }
}
