using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using Persistence.Repositories;
using Core.Helper;
using System.Linq;
using Core.ViewModel;

namespace Core.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreDBContext context)
          : base(context)
        { }

        /// <summary>
        /// Get List Of Product
        /// </summary>
        /// <returns></returns>
        public BaseResponse GetProduct()
        {
            var response = new BaseResponse();
            try
            {

                response.data = this._dbContext.Product.ToList();
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.status = false;
                response.message = ex.ToString();
                return response;
            }

        }
        /// <summary>
        /// Get List Of Product By Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public BaseResponse GetProductByCategory(string category)
        {
            var response = new BaseResponse();
            try
            {
                response.data = this._dbContext.Product.Where(x => x.Category == category).ToList();
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.status = false;
                response.message = ex.ToString();
                return response;
            }
        }
        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductsById(int? id)
        {
            try
            {
                return this._dbContext.Product.Where(x => x.ProductId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product ProductMapping(ProductVm vm)
        {
            var product = vm.MapTo(vm);
            return product;
        }

        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }
    }
}
