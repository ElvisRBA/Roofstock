using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropertiesController : BaseApiController
    {
        private readonly IGenericRepository<RealProperty> _realPropertyRepo;
        private readonly IMapper _mapper;
        public PropertiesController(IGenericRepository<RealProperty> realPropertyRepo, IMapper mapper)
        {
            _mapper = mapper;
            _realPropertyRepo = realPropertyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RealPropertyToReturnDto>>> GetProperties()
        {
            var properties = await _realPropertyRepo.ListAllAsync();

            return Ok(_mapper
            .Map<IReadOnlyList<RealProperty>, IReadOnlyList<RealPropertyToReturnDto>>(properties));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RealPropertyToReturnDto>> GetProperty(int id)
        {
            var property = await _realPropertyRepo.GetByIdAsync(id);
            return _mapper.Map<RealProperty, RealPropertyToReturnDto>(property);
        }
    }
}