using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSaleApi.Models;

namespace ProductSaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _db;
        private readonly IWebHostEnvironment _web;

        public ProductsController(ProductDbContext db, IWebHostEnvironment web)
        {
            _db = db;
            _web = web;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_db.Products == null)
            {
                return NotFound("Table not found");
            }
            return await _db.Products.ToListAsync();

        }

        [HttpGet("Sales/Include")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithSale()
        { 
        return await _db.Products
                .Include(p=>p.Sales).ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (id == null)
            {
                return NotFound("Id not found");
            }
            return await _db.Products.FindAsync(id);

        }
        [HttpGet("{id}/Include")]
        public async Task<ActionResult<Product>> GetProductsWithSale(int id)
        {
            var product=await _db.Products.Include(p=>p.Sales).FirstOrDefaultAsync(p=>p.ProductId==id);
            return product;
                    
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        { 
        _db.Products.Add(product);
           await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductsWithSale), new
            {
                id = product.ProductId
               
            },product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product =await _db.Products.FindAsync(id);
            if(product==null)
            {
                return NotFound("porduct not found");

            }
            _db.Products.Remove(product);
           await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
           if(id!=product.ProductId)
            {
                return BadRequest("Product Id mismatch");
            }
            var existingProduct = await _db.Products.Include(p => p.Sales).FirstOrDefaultAsync(p => p.ProductId == id);
            if (existingProduct == null)
            {
                return NotFound("porduct not found");
            }
            _db.Entry(existingProduct).State= EntityState.Modified;
            foreach (var sale in existingProduct.Sales)
            {
                if (sale.SaleId != 0)
                {
                    _db.Entry(sale).State = EntityState.Modified;
                }
                else
                {
                    _db.Entry(sale).State = EntityState.Added;
                }
                
            }
            var idsOfSale = product.Sales.Select(s => s.SaleId).ToList();
            var saletodelete = await _db.Sales.Where(s => !idsOfSale.Contains(s.ProductId) && s.ProductId == product.ProductId).ToListAsync();
            if (saletodelete.Count > 0)
            {
                _db.Sales.RemoveRange(saletodelete);
            }
            await _db.SaveChangesAsync();
            return NotFound();
        }
    }
    

}
