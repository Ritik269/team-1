using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiTrade.Models
{
    public class Sales_Invoice
    {
        [Key]
        public int InvoiceNumber { get; set; }    // Primary Key - Auto-incremented
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InvoiceDate { get; set; }

        //public date InvoiceDate { get; set; }
        
        [DisplayFormat(NullDisplayText = "No Customer")]
        [Display(Name = "Customer")]
        public int? CustomerID { get; set; }
        [Display(Name = "Customer")]
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }



        [DisplayFormat(NullDisplayText = "No Product")]
        [Display(Name = "Product")]
        public int? ProductID { get; set; }
        [Display(Name = "Product")]
        [ForeignKey("ProductID")]
        
        public Product Product { get; set; }


        [Required]
        [Range(16, 64, ErrorMessage = "Maximum of 64 MP only and Minimum 64 MP only !")]
        public int Qty { get; set; }
        public int Rate { get; set; }
        
    }
}
