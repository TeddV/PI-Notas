using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniNotasApi.Data;
using UniNotasApi.Models;

namespace UniNotasApi.Controllers
{
    
    [Route("v1/book")]
    public class BookController : Controller
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Book>>> Get([FromServices] UniNotasContext context)
        {
            var books = await context.books.AsNoTracking().ToListAsync();
            return books;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Book>> GetById([FromServices] UniNotasContext context, int id)
        {
            var books = await context.books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return books;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Book>> Post(
            [FromServices] UniNotasContext context,
            [FromBody]Book model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.books.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a nota" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Book>> Put(
            [FromServices] UniNotasContext context,
            int id,
            [FromBody]Book model)
        {
            if (id != model.Id)
                return NotFound(new { message = "Nota não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Book>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a nota" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> Delete(
            [FromServices] UniNotasContext context,
            int id)
        {
            var book = await context.books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound(new { message = "Nota não encontrada" });

            try
            {
                context.books.Remove(book);
                await context.SaveChangesAsync();
                return book;
            }
            catch (Exception)

            {
                return BadRequest(new { message = "Não foi possível remover a nota" });

            }
        }
    }
}