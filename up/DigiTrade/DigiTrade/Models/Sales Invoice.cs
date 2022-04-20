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
       
        [Display(Name = "Customer")]
        public virtual int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }


        
        [Display(Name = "Product")]
        public virtual int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        


        [Required]
        [Range(1, 10, ErrorMessage = "Maximum of 10 Qty  and Minimum 1 Qty only !")]
        public int Qty { get; set; }
        public int Rate { get; set; }
        
    }
}
