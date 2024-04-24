using ApiExamenValen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenValen.Data
{
    public class PersonajesContext:DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
