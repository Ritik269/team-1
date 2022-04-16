using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigiTradeService.Products;
using System.Collections.Generic;
using DigiTradeData.Models;
using System.Threading.Tasks;


namespace DigiTradeGS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService proService = new ProductService();
        [HttpGet]
        // https://localhost:44351/api/Employee
        public IEnumerable<Product> Index() // => emp.GetActiveEmployees();
        {
            //return empService.GetActiveEmployees();
            return proService.GetProduct();
        }
        [HttpGet("{id}")]
        // https://localhost:44351/api/Employee/2
        public ActionResult<Product> Index(int id)
        {
            return proService.GetProduct(id);
        }
        [HttpPost]
        // https://localhost:44351/api/Employee
        // pass employee object in request body
        public async Task<ActionResult<Product>> PostProduct(Product pro)
        {
            if (!ModelState.IsValid)
            {
                throw new System.Exception("Invalid Product");
            }
            else
            {
                proService.AddProduct(pro);
                return pro;
            }
        }
        [HttpPut("{id}")]
        
        // https://localhost:44351/api/Employee/2
        // pass employee object in request body
        public async Task<ActionResult<Product>> PutProduct(short id, Product pro)
        {
            if (id != pro.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                throw new System.Exception("Invalid Product");
            }
            else
            {
                proService.UpdateProduct(pro);
                return pro;
            }
        }

    }
}
