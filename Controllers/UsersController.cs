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
    public class UsersController : ControllerBase
    {
        private readonly medProDBContext _context;

        public UsersController(medProDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("login/{email}/{Password}")]
        public async Task<ActionResult<User>> GetUser(string email, string Password)
        {
          var id = (from u in _context.Users where u.Email == email select u.UserId).First();
          var user = await _context.Users.FindAsync(id);

          

          if (user == null)
          {
            return NotFound();
          }

          if (user.Email == email && user.Password == Password)
          {
            return user;
          }
          else return BadRequest("Wrong password, please try again");
        }


        [HttpGet("doc")]
        public IActionResult GetDoc()
        {
            var doc = from c in _context.Users
                      where c.Role == 2
                      select c;
            return Ok(doc);
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
      if (user.Role == 1)
      {
        Patient patient = new Patient();
        patient.UserId = user.UserId;
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
      }
      else if (user.Role == 2)
      {
        Doctor doctor = new Doctor();
        doctor.UserId = user.UserId;
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
      }
      return CreatedAtAction("GetUser", new { id = user.UserId }, user);
         

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
