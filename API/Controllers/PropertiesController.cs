using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropertiesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IRealPropertyService _realPropertyService;

        // Injecting the property service and the mapper to be  consumed all over the controller.
        public PropertiesController(IRealPropertyService realPropertyService, IMapper mapper)
        {
            _realPropertyService = realPropertyService;
            _mapper = mapper;
        }

        // This method is responsible for calling the service to get the properties list and return the list to the client.
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RealPropertyDto>>> GetProperties()
        {
            var properties = await _realPropertyService.GetRealPropertiesAsync();

            return Ok(_mapper.Map<IReadOnlyList<RealProperty>, IReadOnlyList<RealPropertyDto>>(properties));
        }

        // This method is responsible for calling the service to get a specific property by its id and return it to the client.
        [HttpGet("{id}")]
        public async Task<ActionResult<RealPropertyDto>> GetProperty(int id)
        {
            var property = await _realPropertyService.GetRealPropertyByIdAsync(id);

            if (property == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<RealProperty, RealPropertyDto>(property);
        }

        // This method is responsible for calling the service to creating a property and return it to the client.
        [HttpPost]
        public async Task<ActionResult<RealProperty>> CreateRealProperty(RealProperty realProperty)
        {
            var property = await _realPropertyService.CreateRealPropertyAsync(realProperty);

            if (property == null) return BadRequest(new ApiResponse(400, "Problem creating property"));

            return Ok(property);
        }
    }
}