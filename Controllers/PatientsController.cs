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
  public class PatientsController : ControllerBase
  {
    private readonly medProDBContext _context;

    public PatientsController(medProDBContext context)
    {
      _context = context;
    }

    // GET: api/Patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
      return await _context.Patients.ToListAsync();
    }

    // GET: api/Patients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
      var patient = await _context.Patients.FindAsync(id);

      if (patient == null)
      {
        return NotFound();
      }

      return patient;
    }
  }
}