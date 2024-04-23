using Ardalis.Result;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shipping_managment_system.Application.Abstraction;
using Shipping_managment_system.Application.CQRS.Address.GetSingleAddress;
using Shipping_managment_system.Application.CQRS.Cargo.GetSingleCargo;
using Shipping_managment_system.Application.CQRS.Cargo.GetTotalPrice;
using Shipping_managment_system.Application.CQRS.Shipment.AcceptShipment;
using Shipping_managment_system.Application.CQRS.Shipment.AddShipment;
using Shipping_managment_system.Application.CQRS.Shipment.GetAllShipments;
using Shipping_managment_system.Application.CQRS.Shipment.GetSingleShipment;
using Shipping_managment_system.Application.DTO.Shipment.Request;
using Shipping_managment_system.Application.DTO.Shipment.response;
using Shipping_managment_system.Application.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shipping_managment_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<EventHub, IMessageHubClint> _hubContext;

        public ShipmentController(IMediator mediator, IHubContext<EventHub, IMessageHubClint> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        // GET: api/<ShipmentController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllShipments()
        {
            var result = await _mediator.Send(new GetAllShipmentQuery());
            //List<GetShipmentResponse> responses = new List<GetShipmentResponse>();

            //foreach (var item in result.Value)
            //{
            //    var cargoResult = await _mediator.Send(new GetSingleCargoQuery(item.CargoId.value));
            //    var startLocationResult = await _mediator.Send(new GetSingleAddressQuery(item.StartLocation.value));
            //    var endLocationResult = await _mediator.Send(new GetSingleAddressQuery(item.EndLocation.value));

            //    if (cargoResult.IsSuccess && startLocationResult.IsSuccess && endLocationResult.IsSuccess)
            //    {
            //        var cargo = cargoResult.Value;
            //        var startLocation = startLocationResult.Value;
            //        var endLocation = endLocationResult.Value;

            //        var shipmentResponse = new GetShipmentResponse(item.Title, item.Description, item.Status, item.ShipmentDate, item.CreationDate, item.userId, startLocation, endLocation, cargo);
            //        responses.Add(shipmentResponse);
            //    }
            //    else
            //    {
            //        // Log the errors
            //        Console.WriteLine($"Error fetching cargo or address for shipment {item.Id.value}");
            //    }
            //}

            return Ok(result);
        }


        // GET api/<ShipmentController>/5
        [HttpGet("GetSingleShipment/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetSingleShipmentQuery(id));
            return Ok(result);
        }

        // GET api/<ShipmentController>/5
        [HttpGet("Accept/{id}")]
        public async Task<IActionResult> AcceptShipment(Guid id)
        {
            var result = await _mediator.Send(new AcceptShipementCommand(id));
            return Ok(result);
        }

        // POST api/<ShipmentController>
        [HttpPost("CreateShipment")]
        public async Task<IActionResult> Post([FromBody] CreateShipmentRequest Request)
        {
            var result = await _mediator.Send(new AddShipmentCommand(Request.CargoType,Request.Weight,Request.StartLocation,Request.EndLocation,Request.Title,Request.Description,Request.ShipmentDate,Request.userId));

            //await _hubContext.Clients.User(Request.userId.ToString()).SendAsync("ReceiveShipmentCreated", result);

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

        [HttpPost("GetTotalPrice")]
        public async Task<IActionResult> GetTotalPrice(GetTotalPriceRequest request)
        {
            var result = await _mediator.Send(new GetTotalPriceQuery(request.CargoType, request.Weight, request.StartLocation, request.EndLocation));

            return Ok(result);
        }

        //[HttpGet]
        //[Route("productoffers")]
        //public string getOffer()
        //{
            
        //    _hubContext.Clients.All.SendOffersToUser("Hello");
        //    return "Offers sent successfully to all users!";
        //}

    }
}
