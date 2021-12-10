using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
     [Route("pedido")]
     [ApiController]
     public class OrderController : ControllerBase
    {      
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Order>>> Get(
            [FromServices]DataContext context
        )
        {
            var orders = await context.pedido            
            .AsNoTracking()
            .ToListAsync();
            return Ok(orders);
        } 


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Order>>> GetById(
            [FromServices]DataContext context,
            int id
        )
        {
            var orders = await context.pedido
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.id == id);
            return Ok(orders);
        }              
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Order>>> Post(
            [FromBody]Order model,
            [FromServices]DataContext context
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
        try{
            context.pedido.Add(model);  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch{
            return BadRequest(new  { message = "Não foi possível criar o pedido!"});
            } 
        }
        
    }
}