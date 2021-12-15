using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

// Endpoint => URL
// http://localhost:5000 ou https://localhost:5001 
[Route("pessoa")]
[ApiController]
public class PeopleController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<People>>> Get(
        [FromServices] DataContext context
    )
    {
        var pessoas = await context.pessoa
        .AsNoTracking()
        .ToListAsync();
        return Ok(pessoas);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<People>> GetById(int id,
    [FromServices] DataContext context
    )
    {
        try
        {
            return await context.Set<People>().FindAsync(id);
        }
        catch
        {
            return BadRequest(new { message = "Cadastro não encontrado, verifique e tente novamente!" });
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<People>>> Post(
        [FromBody] People model,
        [FromServices] DataContext context
        )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            context.pessoa.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível realizar o cadastro" });
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
            context.Entry(model).Property(x => x.nome).IsModified = true;   
            await context.SaveChangesAsync();
            return Ok(model);        
            }
        catch(DbUpdateConcurrencyException o)
        {
            return BadRequest(new  { message = "Não foi possível Atualizar o Cadastro" + o});
        }  
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<People>>> Delete(
        int id,
        [FromServices] DataContext context
    )
    {
        var pessoas = await context.pessoa.FirstOrDefaultAsync(x => x.id == id);
        if (pessoas == null)
            return NotFound(new { message = "Pessoa não encontrada" });

        try
        {
            context.pessoa.Remove(pessoas); ;
            await context.SaveChangesAsync();
            return Ok(new { message = "Cadastro Removido com sucesso!" });
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Não foi possível Atualizar o cadastro" });
        }
    }
}
