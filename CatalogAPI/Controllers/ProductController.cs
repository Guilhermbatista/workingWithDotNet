using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {

            var products = _context.Product.Include(p => p.Category).AsNoTracking().ToList();

            if (products is null)
            {
                return NotFound("Products Not Found");
            }
            return _context.Product.ToList();
        } 
        
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Product> GetProductId(int id)
        {
            var product = _context.Product.AsNoTracking().FirstOrDefault(p => p.ProductId == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            return product;
        }
        [HttpPost]
        public ActionResult PostProduct (Product product)
        {
            if (product is null)
                return BadRequest();

            _context.Product.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = product.ProductId }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }


            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);

        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Product.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }
            _context.Product.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
