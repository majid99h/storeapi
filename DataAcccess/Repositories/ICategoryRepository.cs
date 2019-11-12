
using Core.Domain;
using Core.Helper;

namespace Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        BaseResponse GetCategory();
    }
}
