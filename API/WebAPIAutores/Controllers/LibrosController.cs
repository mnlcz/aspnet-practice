using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Models;

namespace WebAPIAutores.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibrosController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Libro?>> Get(int id)
    {
        return await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult<Libro?>> Post(Libro libro)
    {
        var existe = await _context.Autores.AnyAsync(x => x.Id == libro.AutorId);

        if (!existe)
            return BadRequest($"No existe el autor de Id: {libro.AutorId}");

        _context.Add(libro);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
