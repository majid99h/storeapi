using Core.Domain;
using Core.Helper;
using Core.ViewModel;

namespace Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        BaseResponse GetProduct();
        BaseResponse GetProductByCategory(string category);
        Product GetProductsById(int? id);
        Product ProductMapping(ProductVm product);
    }
}
