using System;
using System.Collections.Generic;

#nullable disable

namespace DigiTradeData.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string Discription { get; set; }
        public int SalePrice { get; set; }
        
    }
}
