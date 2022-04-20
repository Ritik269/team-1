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
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Only Positive Value")]
        
        public uint SalePrice { get; set; }
        [Required]
        public uint Cur_Stock { get; set; }
        [Required]
        public uint Tax { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public virtual int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        

        [Required]
        [StringLength(15, ErrorMessage = "Maximum of 15 Characters only !")]
        public string Processor { get; set; }

        [Required]
        [Range(8, 16, ErrorMessage = "Maximum of 16 GB and Minimum 8 GB only !")]
        public uint RAM { get; set; }

        [Required]
        [Range(16, 128, ErrorMessage = "Maximum of 128 GB only and Minimum 16 GB only !")]
        public uint ROM { get; set; }
        [Required]
        [Range(32, 108, ErrorMessage = "Maximum of 108 GB only and Minimum 32 GB only !")]
        public uint PrimaryCamera { get; set; }
        [Required]
        [Range(16, 64, ErrorMessage = "Maximum of 64 MP only and Minimum 64 MP only !")]
        public uint FrontCamera { get; set; }
        [Required]
        [Range(1000, 5000, ErrorMessage = "Maximum of 5000 mAH only and Minimum 1000 mAH only !")]
        public uint Battery { get; set; }


    }

}

