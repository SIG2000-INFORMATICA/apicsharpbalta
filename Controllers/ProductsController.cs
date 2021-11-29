using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
     [Route("products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get(
            [FromServices]DataContext context
        )
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .ToListAsync();
            return Ok(products);
        } 
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Product>>> GetById(
            [FromServices]DataContext context,
            int id
        )
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(products);
        } 
        
         [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategoriy(
            [FromServices]DataContext context,
            int id
        )
        {
            var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
            return Ok(products);
        }  

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Post(
            [FromBody]Category model,
            [FromServices]DataContext context
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
        try{
            context.Categories.Add(model);  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch{
            return BadRequest(new  { message = "Não foi possível criar a categoria"});
            }  

        }
        
    }
}