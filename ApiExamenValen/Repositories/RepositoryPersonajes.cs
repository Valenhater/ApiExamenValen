using ApiExamenValen.Data;
using ApiExamenValen.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenValen.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }
        public async Task<List<Personaje>> GetPersonajesSerieAsync(string serie)
        {
            return await this.context.Personajes.Where(x => x.Serie == serie).ToListAsync();
        }
        public async Task<List<string>> GetSeriesAsync()
        {
            return await this.context.Personajes.Select(p => p.Serie).Distinct().ToListAsync();
        }
        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }
        public async Task InsertarPersonajeAsync(Personaje person)
        {
            this.context.Personajes.Add(person);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonajeAsync(Personaje person)
        {
            this.context.Personajes.Update(person);
            await this.context.SaveChangesAsync();
        }
        public async Task DeletePersonajeAsync(int id)
        {
            Personaje person = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(person);
            await this.context.SaveChangesAsync();
        }
    }
}
