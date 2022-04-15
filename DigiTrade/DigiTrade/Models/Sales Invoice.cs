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
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        [ForeignKey("Product")]
        public int Product { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
        
    }
}
