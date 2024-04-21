using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shipping_managment_system.Application.CQRS.Shipment.AddShipment;
using Shipping_managment_system.Application.DTO.Shipment.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shipping_managment_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ShipmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(ModelState);
        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShipmentController>
        [HttpPost("CreateShipment")]
        public async Task<IActionResult> Post([FromBody] CreateShipmentRequest Request)
        {
            var result = await _mediator.Send(new AddShipmentCommand(Request.CargoType,Request.Weight,Request.StartLocation,Request.EndLocation,Request.Title,Request.Description,Request.ShipmentDate,Request.userId));

            return Ok(result);
        }

        // PUT api/<ShipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
