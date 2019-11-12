using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
            [HttpGet]
            [Route("/api/GetCartDetail")]
            public IActionResult GetCartDetail(string cartid)
            {
                using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
                {
                    var response = unitOfWork.Cart.GetCartDetailById(cartid);
                    return Ok(response);
                }
            }

            [HttpPost]
            [Route("/api/AddToCart")]
            public IActionResult AddToCart(CartDetail cartItem)
            {
                using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
                {
                    var response = unitOfWork.Cart.AddToCart(cartItem);
                    return Ok(response);
                }
            }
        [HttpPost]
        [Route("/api/RemoveCartItem")]
        public IActionResult RemoveCartItem(CartDetail cartItem)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Cart.RemoveCartItem(cartItem);
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("/api/GetCartCount")]
        public IActionResult GetCartCount(string cartid)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Cart.CartCount(cartid);
                return Ok(response);
            }
        }

    }
}