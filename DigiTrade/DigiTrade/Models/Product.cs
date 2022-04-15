using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiTrade.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }    // Primary Key - Auto-incremented

        [Required]
        [StringLength(15, ErrorMessage = "Maximum of 15 Characters only !")]
        [MinLength(3, ErrorMessage = "Minimum of 3 Characters required !")]
        public string ProductTitle { get; set; }

        [StringLength(64, ErrorMessage = "Maximum of 64 Characters only !")]
        public string Discription { get; set; }
        
        [Required(ErrorMessage = "Only Positive Value")]
        public uint SalePrice { get; set; }


    }

}

