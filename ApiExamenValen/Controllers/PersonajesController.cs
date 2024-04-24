using ApiExamenValen.Models;
using ApiExamenValen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenValen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }
        [HttpGet("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSeries(string serie)
        {
            return await this.repo.GetPersonajesSerieAsync(serie);
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<string>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Personaje>> GetPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Personaje>> InsertPersonaje(Personaje person)
        {
            await this.repo.InsertarPersonajeAsync(person);
            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<ActionResult<Personaje>> UpdatePersonaje(Personaje person)
        {
            await this.repo.UpdatePersonajeAsync(person);
            return Ok();
        }
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Personaje>> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
