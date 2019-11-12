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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("/api/GetCategory")]
        public IActionResult GetCategory()
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Category.GetCategory();
                return Ok(response);
            }
        }
    }
}