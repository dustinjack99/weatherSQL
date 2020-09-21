using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testreact.Models;

namespace testreact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherAPIController : ControllerBase
    {
        private readonly DbConnectionClass _context;

        public WeatherAPIController(DbConnectionClass context)
        {
            _context = context;
        }

        // GET: api/WeatherAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherModel>>> Getweatherdata()
        {
            return await _context.weatherdata.ToListAsync();
        }

        // GET: api/WeatherAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherModel>> GetWeatherModel(int id)
        {
            var weatherModel = await _context.weatherdata.FindAsync(id);

            if (weatherModel == null)
            {
                return NotFound();
            }

            return weatherModel;
        }

        // PUT: api/WeatherAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherModel(int id, WeatherModel weatherModel)
        {
            if (id != weatherModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeatherModel>> PostWeatherModel([FromBody] WeatherModel weatherModel)
        {
            _context.weatherdata.Add(weatherModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherModel", new { id = weatherModel.Id }, weatherModel);
        }

        // DELETE: api/WeatherAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherModel>> DeleteWeatherModel(int id)
        {
            var weatherModel = await _context.weatherdata.FindAsync(id);
            if (weatherModel == null)
            {
                return NotFound();
            }

            _context.weatherdata.Remove(weatherModel);
            await _context.SaveChangesAsync();

            return weatherModel;
        }

        private bool WeatherModelExists(int id)
        {
            return _context.weatherdata.Any(e => e.Id == id);
        }
    }
}
