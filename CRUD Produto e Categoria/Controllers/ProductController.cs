using CRUD_Produto_e_Categoria.Context;
using CRUD_Produto_e_Categoria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Produto_e_Categoria.Controllers
{
    // Controllers/ProductController.cs
    [ApiController]
    [Route("api/products")]
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
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            try
            {
                if (product == null)
                    return NotFound($"Produto com id= {id} não encontrada...");

                return product;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);

            try
            {
                if (product == null)
                    return NotFound();

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);

                if (product == null)
                    return NotFound($"Produto com id={id} não encontrada...");

                _context.Products.Remove(product);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }
    }

}
