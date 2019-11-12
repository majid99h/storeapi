using Core;
using Core.Domain;
using Core.Helper;
using Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IOptions<AppSettings> appSettings;
        //public ProcessController(IOptions<AppSettings> app)
        //{
        //    appSettings = app;
        //}

        //[HttpPost]
        //[Route("/api/CreateProcess")]
        //public IActionResult CreateProcess()
        //{

        //    using (var unitOfWork = new UnitOfWork(new PacMatDBContext()))
        //    {
        //        var file = Request.Form.Files[0];
        //        var name = Request.Form["name"].ToString();
        //        if (file.Length > 0)
        //        {

        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine("Upload", fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //                unitOfWork.Distributor.UploadFile(stream, appSettings.Value.ConnectionString);
        //            }

        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //}

        [HttpGet]
        [Route("/api/GetProducts")]
        public IActionResult GetProducts()
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Product.GetProduct();
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("/api/GetProductByCategory")]
        public IActionResult GetProductByCategory(string category)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var response = unitOfWork.Product.GetProductByCategory(category);
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("/api/GetProductById")]
        public IActionResult GetProductById(int id)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                Product response = unitOfWork.Product.GetProductsById(id);
                return Ok(response);
            }
        }

        [HttpPost]
        [Route("/api/AddProduct")]
        public IActionResult AddProduct(ProductVm productVm)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var product = unitOfWork.Product.ProductMapping(productVm);
                unitOfWork.Product.Add(product);
                unitOfWork.Complete();
                return Ok();
            }
        }
        [HttpPost]
        [Route("/api/EditProduct")]
        public IActionResult EditProduct(ProductVm productVm)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var product = unitOfWork.Product.ProductMapping(productVm);
                if (product != null)
                {
                    unitOfWork.Product.Update(product);
                    unitOfWork.Complete();
                }
                return Ok();
            }
        }

    }
}