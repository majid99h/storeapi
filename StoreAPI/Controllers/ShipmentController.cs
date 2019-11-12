using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        [HttpPost]
        [Route("/api/SendShipment")]
        public IActionResult SendShipment(Shipment shipment)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Shipment.SaveShipment(shipment);
                return Ok(response);
            }
        }
    }
}