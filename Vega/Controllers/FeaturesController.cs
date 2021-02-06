
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;
using Vega.Services;

namespace Vega.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController: ControllerBase
    {
        private readonly VegaDbContext _context;
        public FeaturesController(VegaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Feature>> GetFeatures()
        {
            var featuresFromRepo = _context.Features.ToList();
            
            return Ok(featuresFromRepo);
        }

        [HttpGet("{id}")]
        public ActionResult<Feature> GetFeature(int id)
        {
            var featureFromRepo = _context.Features.SingleOrDefault(f => f.Id == id);
            if (featureFromRepo == null) return NotFound();

            return Ok(featureFromRepo);
        }
    }
}
