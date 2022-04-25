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
  public class DoctorsController : ControllerBase
  {
    private readonly medProDBContext _context;

    public DoctorsController(medProDBContext context)
    {
      _context = context;
    }

    // GET: api/Doctors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
    {
      return await _context.Doctors.ToListAsync();
    }

    // GET: api/Doctors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctor(int id)
    {
      var doctor = await _context.Doctors.FindAsync(id);

      if (doctor == null)
      {
        return NotFound();
      }

      return doctor;
    }


  }
}