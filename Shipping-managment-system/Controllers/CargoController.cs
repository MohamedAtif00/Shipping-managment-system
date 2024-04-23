using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shipping_managment_system.Application.CQRS.Cargo.GetSingleCargo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shipping_managment_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CargoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CargoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetSingleCargoQuery(id));

            return Ok(result);
        }

        // POST api/<CargoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CargoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CargoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
