#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedPro.Models.EF;

namespace MedPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorservicesController : ControllerBase
    {
        private readonly medProDBContext _context;

        public DoctorservicesController(medProDBContext context)
        {
            _context = context;
        }

        // GET: api/Doctorservices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctorservice>>> GetDoctorservices()
        {
            return await _context.Doctorservices.ToListAsync();
        }

        // GET: api/Doctorservices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctorservice>> GetDoctorservice(int id)
        {
            var doctorservice = await _context.Doctorservices.FindAsync(id);

            if (doctorservice == null)
            {
                return NotFound();
            }

            return doctorservice;
        }

        // PUT: api/Doctorservices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorservice(int id, Doctorservice doctorservice)
        {
            if (id != doctorservice.DsId)
            {
                return BadRequest();
            }

            _context.Entry(doctorservice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorserviceExists(id))
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

        // POST: api/Doctorservices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctorservice>> PostDoctorservice(Doctorservice doctorservice)
        {
            _context.Doctorservices.Add(doctorservice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorservice", new { id = doctorservice.DsId }, doctorservice);
        }

        // DELETE: api/Doctorservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorservice(int id)
        {
            var doctorservice = await _context.Doctorservices.FindAsync(id);
            if (doctorservice == null)
            {
                return NotFound();
            }

            _context.Doctorservices.Remove(doctorservice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorserviceExists(int id)
        {
            return _context.Doctorservices.Any(e => e.DsId == id);
        }
    }
}
