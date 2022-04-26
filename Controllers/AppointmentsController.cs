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
    public class AppointmentsController : ControllerBase
    {
        private readonly medProDBContext _context;

        public AppointmentsController(medProDBContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var date = (from t in _context.Times where t.TimeId == appointment.TimeId select t.TimeStart).First();
            var docUserId = (from d in _context.Doctors where d.DocId == appointment.DocId select d.UserId).First();
            var docName = (from u in _context.Users where u.UserId == docUserId select u.LastName).First();

            return Content("" + date + " - Dr. " + docName);
        }

        //Khrystyna
        [HttpGet("patient/{userID}")]
        public IActionResult GetPatient(int userID)
        {
            var patient = (from c in _context.Patients
                           where c.UserId == userID
                           select new { c.PId }).Single();


            int MyVar3 = patient.PId;
            var app = from c in _context.Appointments
                      where c.PId == MyVar3
                      select c;
            Appointment[] appts = app.ToArray();
            List<String> userAppts = new List<String>();

            foreach (Appointment a in appts)
            {
                //var appointment = _context.Appointments.FindAsync(a.ApptId);
                var date = (from t in _context.Times where t.TimeId == a.TimeId select t.TimeStart).First();
                var docUserId = (from d in _context.Doctors where d.DocId == a.DocId select d.UserId).First();
                var docName = (from u in _context.Users where u.UserId == docUserId select u.LastName).First();
                userAppts.Add("" + date + " - Dr. " + docName);
            }

            return Ok(userAppts);
        }


        //Khrystyna
        [HttpGet("doctor/{{userID}}")]
        public IActionResult GetDocAppts(int docId)
        {
            var app = from c in _context.Appointments
                      where c.DocId == docId
                      select c;
            Appointment[] appts = app.ToArray();
            List<String> docAppts = new List<String>();

            foreach (Appointment a in appts)
            {
                //var appointment = _context.Appointments.FindAsync(a.ApptId);
                var date = (from t in _context.Times where t.TimeId == a.TimeId select t.TimeStart).First();
                var patUserId = (from p in _context.Patients where p.PId == a.PId select p.UserId).First();
                var patFirstName = (from u in _context.Users where u.UserId == patUserId select u.FirstName).First();
                var patLastName = (from u in _context.Users where u.UserId == patUserId select u.LastName).First();
                docAppts.Add("" + date + " -  " + patFirstName + " " + patLastName);
            }

            return Ok(docAppts);
        }

        //Khrystyna
        [HttpPost("MakeAppointment/{userId}/{userDocID}/{date}")]
        public async Task<ActionResult<Appointment>> PostAppointment(int userId, int userDocID, DateTime date)
        {
            var doc = (from c in _context.Doctors
                       where c.UserId == userDocID
                       select new { c.DocId }).Single();

            int MyVar = doc.DocId;
            var time = (from c in _context.Times
                        where c.TimeStart == date
                        select new { c.TimeId }).Single();
            int MyVar2 = time.TimeId;

            Appointment appointment = new Appointment();
            appointment.PId = userId;
            appointment.DocId = MyVar;
            appointment.TimeId = MyVar2;


            int appoinCheck = (from c in _context.Appointments
                               where c.TimeId == MyVar2 && c.DocId == MyVar
                               select c).Count();
            if (appoinCheck > 0)
            {
                return NotFound();
            }
            else
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAppointment", new { id = appointment.ApptId }, appointment);
            }
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.ApptId)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.ApptId }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.ApptId == id);
        }
    }
}
