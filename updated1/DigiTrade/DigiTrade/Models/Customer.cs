using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiTrade.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }    // Primary Key - Auto-incremented

        [Required]
        [StringLength(20, ErrorMessage = "Maximum of 20 Characters only !")]
        [MinLength(2, ErrorMessage = "Minimum of 3 Characters required !")]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Maximum of 12 Characters only !")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(128, ErrorMessage = "Email Phone should be in raj123@gmail.com format")]
        public string Email { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Maximum of 64 Characters only !")]
        public string Address { get; set; }

    }
}
