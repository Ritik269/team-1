using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiTradeData.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiTradeData.Repositories
{
    public class ProductRepositories
    {
        private ProductContext _dbDigiTrade;
        
        private IEnumerable<Product> _Products;
        public ProductRepositories()
        {
            _dbDigiTrade = new ProductContext();
            _Products = _dbDigiTrade.Products;
        }
        public IEnumerable<Product> GetProduct()
        {
            return _Products;
        }
        //public IEnumerable<Product> GetActiveProduct()
        //{
        //    var products = _Products.Where(e => e.IsActive == true);
        //    return products;
        //}
        public Product GetProduct(int id)
        {
            Product product = _Products.FirstOrDefault(pro => pro.Id == id);
            return product;
        }
        public Product AddProduct(Product product)
        {
            _dbDigiTrade.Products.Add(product);
            _dbDigiTrade.SaveChangesAsync();
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            _dbDigiTrade.Update(product);
            _dbDigiTrade.SaveChangesAsync();
            return product;
        }

    }
}
