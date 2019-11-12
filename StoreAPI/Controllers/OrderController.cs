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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [Route("/api/SaveOrder")]
        public IActionResult SaveOrder(Shipment ship)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Order.SaveOrder(ship);
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("/api/GetOrder")]
        public IActionResult GetOrder()
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Order.GetOrders();
                return Ok(response);
            }
        }
    }
}