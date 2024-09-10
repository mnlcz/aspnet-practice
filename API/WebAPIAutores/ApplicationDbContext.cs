using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Models;

namespace WebAPIAutores;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
}
