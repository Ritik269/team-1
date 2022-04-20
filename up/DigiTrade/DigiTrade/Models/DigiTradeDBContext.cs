using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DigiTrade.Models
{
    public class DigiTradeDBContext : DbContext
    {
        public DigiTradeDBContext()
        {
        }

        public DigiTradeDBContext(DbContextOptions<DigiTradeDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Sales_Invoice> Sales_Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
