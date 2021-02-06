using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Vega.Services;
using Microsoft.EntityFrameworkCore;
using Vega.Models;
using Vega.Dtos;
using AutoMapper;

namespace Vega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MakesController : ControllerBase
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public IActionResult GetMakes()
        //{
        //    var makes = _context.Makes.ToList();

        //    return Ok(makes);
        //}
        [HttpGet]
        public ActionResult<IEnumerable<MakeDto>> GetMakes()
        {
            var makesFromRepo = _context.Makes.Include(m => m.Models).ToList<Make>();
            return Ok(_mapper.Map<IEnumerable<MakeDto>>(makesFromRepo)); 
        }

        [HttpGet("{id}")]
        public ActionResult<MakeDto> GetMake(int id)
        {
            var makeFromRepo = _context.Makes.Include(m => m.Models).SingleOrDefault(m => m.Id == id);
            return Ok(_mapper.Map<MakeDto>(makeFromRepo));
        }
    }
}
