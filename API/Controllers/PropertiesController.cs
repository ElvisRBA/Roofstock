using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly RoofstockContext _context;
        public PropertiesController(RoofstockContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<RealProperty>>> GetProperties()
        {
            var properties = await _context.Properties.ToListAsync();

            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealProperty>> GetProperty(int id)
        {
            return await _context.Properties.FindAsync(id);
        }
    }
}