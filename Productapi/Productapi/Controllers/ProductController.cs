using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productapi.Models;

namespace Productapi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        public List<Product> products;
        public ProductController()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    Name ="Bob",
                    Id=1,
                    Description="text123",
                },
                 new Product()
                {
                    Name ="steve",
                    Id=2,
                    Description="text456",
                },
                  new Product()
                {
                    Name ="john",
                    Id=3,
                    Description="789text",
                },
            };
        }
        [HttpGet("getAllProducts")]
        public IActionResult getAllProducts()
        {
            return Ok(products);
        }

        [HttpPost("create")]
        public IActionResult AddProduct([FromBody]Product product)
        {
            if (!string.IsNullOrEmpty(product.Name) && !string.IsNullOrEmpty(product.Description))
            {
                products.Add(product);
                return new ObjectResult(products);
            }
            else return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult updateProduct([FromBody] Product product,string id)
        {
            try
            {
                var response = product.updateColor(product, id);
                return Ok(response);
            }
            catch 
            {
                return BadRequest("update unsuccesful");
            }
        }

        [HttpDelete("delete")]
        public IActionResult deleteProduct(int id)
        {

            try
            {
                products.RemoveAt(id);

                return Ok();
            }
            catch 
            {
                return BadRequest("delete unsuccesful");
            }
        }
    }
}
