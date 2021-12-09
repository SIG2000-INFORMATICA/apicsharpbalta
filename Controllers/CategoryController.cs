using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

// Endpint => URL
// http://localhost:5000 ou https://localhost:5001 
[Route("categoria")]
[ApiController]
public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get(
            [FromServices]DataContext context
        )
        {
            var categories = await context.categoria.AsNoTracking().ToListAsync();
            return Ok(categories);
        } 
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            return new Category();
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
            context.categoria.Add(model);  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch{
            return BadRequest(new  { message = "Não foi possível criar a categoria"});
             }   

        } 
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> Put(
            int id, [FromBody]Category model,
             [FromServices]DataContext context
             )
        {
              if(!ModelState.IsValid) 
                return BadRequest(ModelState);
        try{
            context.Entry<Category>(model).State = EntityState.Modified ;  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new  { message = "Não foi possível Atualizar a categoria"});
        }  

        }  
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> Delete(
            int id, 
            [FromServices]DataContext context
        )
        {
            var category =  await context.categoria.FirstOrDefaultAsync(x=>x.id ==id);
            if(category == null)
            return NotFound(new { message = "Categoria não encontrada"});
        
        try{
            context.categoria.Remove(category); ;  
            await context.SaveChangesAsync();
            return Ok(new { message = "Categoria Removida com sucesso!"});        
            }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new  { message = "Não foi possível Atualizar a categoria"});
        }  
            
     }        
  }
