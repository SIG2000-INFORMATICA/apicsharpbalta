using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
     [Route("produto")]
     [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get(
            [FromServices]DataContext context
        )
        {
            var products = await context.produto
            .Include(x => x.categoria)
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
            var products = await context.produto
            .Include(x => x.categoria)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id);
            return Ok(products);
        } 
        
        [HttpGet]
        [Route("produto/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByproduto(
            [FromServices]DataContext context,
            int id
        )
        {
            var products = await context.produto
            .Include(x => x.categoria)
            .AsNoTracking()
            .Where(x => x.categoriaid == id)
            .ToListAsync();
            return Ok(products);
        }  

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Post(
            [FromBody]Product model,
            [FromServices]DataContext context
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
        try{
            context.produto.Add(model);  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch{
            return BadRequest(new  { message = "Não foi possível criar a categoria"});
            }  

        }
        
    }
}