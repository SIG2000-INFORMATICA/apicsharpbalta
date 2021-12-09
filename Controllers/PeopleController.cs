using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("pessoa")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<People>>> Get(
            [FromServices]DataContext context
        )
        {
            var pessoa = await context.pessoa.AsNoTracking().ToListAsync();
            return Ok(pessoa);
        } 
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<People>> GetById(int id, 
        [FromServices]DataContext context
        )
        {
            return await context.Set<People>().FindAsync(id);        
        } 
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<People>>> Post(
            [FromBody]People model,
            [FromServices]DataContext context
            )
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
        try{
            context.pessoa.Add(model);  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch{
                return BadRequest(new { message = "Não foi possível criar o Cadastro" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<People>>> Put(
            int id, [FromBody] People model,
            [FromServices] DataContext context
            )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
            context.Entry<People>(model).State = EntityState.Modified ;  
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new  { message = "Não foi possível Atualizar o Cadastro"});
        }  

        }  
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<People>>> Delete(
            int id, 
            [FromServices]DataContext context
        )
        {
            var pessoas =  await context.pessoa.FirstOrDefaultAsync(x=>x.id ==id);
            if(pessoas == null)
            return NotFound(new { message = "Cadastro não encontrado"});
        
        try{
            context.pessoa.Remove(pessoas); ;  
            await context.SaveChangesAsync();
            return Ok(new { message = "Cadastro Removido com sucesso!"});        
            }
        catch(DbUpdateConcurrencyException)
        {
            return BadRequest(new  { message = "Não foi possível Atualizar o Cadastro"});
        }              
     } 
    }
}