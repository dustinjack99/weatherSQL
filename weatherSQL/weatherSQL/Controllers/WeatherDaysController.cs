using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weatherSQL.Models;

namespace weatherSQL.Controllers
{
    [Route("api/[WorkDays]")]
    [ApiController]
    public class WeatherDaysController : ControllerBase
    {
        private readonly WeatherContext _context;

        public WeatherDaysController(WeatherContext context)
        {
            _context = context;
        }

        // GET: api/WeatherDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherDay>>> GetWeatherDays()
        {
            return await _context.WeatherDays.ToListAsync();
        }

        // GET: api/WeatherDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherDay>> GetWeatherDay(long id)
        {
            var weatherDay = await _context.WeatherDays.FindAsync(id);

            if (weatherDay == null)
            {
                return NotFound();
            }

            return weatherDay;
        }

        // PUT: api/WeatherDays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherDay(long id, WeatherDay weatherDay)
        {
            if (id != weatherDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDayExists(id))
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

        // POST: api/WeatherDays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeatherDay>> PostWeatherDay(WeatherDay weatherDay)
        {
            _context.WeatherDays.Add(weatherDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeatherDay), new { id = weatherDay.Id }, weatherDay);
        }

        // DELETE: api/WeatherDays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherDay>> DeleteWeatherDay(long id)
        {
            var weatherDay = await _context.WeatherDays.FindAsync(id);
            if (weatherDay == null)
            {
                return NotFound();
            }

            _context.WeatherDays.Remove(weatherDay);
            await _context.SaveChangesAsync();

            return weatherDay;
        }

        private bool WeatherDayExists(long id)
        {
            return _context.WeatherDays.Any(e => e.Id == id);
        }
    }
}
