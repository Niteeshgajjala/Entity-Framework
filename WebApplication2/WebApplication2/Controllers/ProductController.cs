using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext cs;
        public ProductController(AppDbContext c)
        {
            cs = c;
        }
        //retrive data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getemployees()
        {
            return await cs.Product.ToListAsync();
        }
        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await cs.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        //to insert data
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null.");
            }

            cs.Product.Add(product);
            await cs.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        //updatin product
        [HttpPut("{id}")]
        public async Task<IActionResult> updateproduct(int id, [FromBody] Product updatedproduct)
        {
            if (id != updatedproduct.Id)
            {
                return BadRequest("product is mismatch");
            }
            var existingproduct = await cs.Product.FindAsync(id);
            if (existingproduct == null)
            {
                return NotFound("no product found with that id");
            }
            existingproduct.Name = updatedproduct.Name;
            existingproduct.Quantity = updatedproduct.Quantity;
            existingproduct.Price = updatedproduct.Price;

            try
            {
                await cs.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "A concurrency error occurred");
            }
            return NoContent();
        }
        //delete employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteemployee(int id)
        {
            var pro = await cs.Product.FindAsync(id);
            if (pro == null)
            {
                return NotFound("the product is not found with that id");
            }
            cs.Product.Remove(pro);
            await cs.SaveChangesAsync();
            return NoContent();
        }
        
        //product exist or not 
        [HttpGet("exisiting/{id}")]
        public async Task<ActionResult<Product>> existingproduct(int id)
        {
            var pro = await cs.Product.FindAsync(id);
            if (pro == null)
            {
                return NotFound("the product with this id not found");
            }
            return CreatedAtAction(nameof(GetProductById), new { id = pro.Id }, pro);
        }
    }
}