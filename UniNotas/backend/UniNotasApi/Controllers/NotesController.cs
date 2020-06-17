using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniNotasApi.Data;
using UniNotasApi.Models;

namespace UniNotasApi.Controllers
{
    [Route("Notes")]
    public class NotesController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Note>>> Get([FromServices] UniNotasContext context)
        {
            var notes = await context.notes.Include(x => x.Book).AsNoTracking().ToListAsync();
            return notes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Note>> GetById([FromServices] UniNotasContext context, int id)
        {
            var notes = await context.notes.Include(x => x.Book).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return notes;
        }

        [HttpGet]
        [Route("book/{id:int}")]
        public async Task<ActionResult<List<Note>>> GetByCategory([FromServices] UniNotasContext context, int id)
        {
            var notes = await context.notes.Include(x => x.Book).AsNoTracking().Where(x => x.BookId == id).ToListAsync();
            return notes;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Note>> Post(
            [FromServices] UniNotasContext context,
            [FromBody]Note model)
        {
            if (ModelState.IsValid)
            {
                context.notes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}