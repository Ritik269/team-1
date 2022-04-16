using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiTrade.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }    // Primary Key - Auto-incremented

        [Required]
        [StringLength(20, ErrorMessage = "Maximum of 20 Characters only !")]
        [MinLength(2, ErrorMessage = "Minimum of 3 Characters required !")]
        public string BrandName { get; set; }
    }
}
