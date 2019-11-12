using Core.Domain;
using Core.Helper;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        IEnumerable<CartDetailVm> GetCartDetailById(string cartid);
        BaseResponse AddToCart(CartDetail cartItem);
        decimal CartCount(string cartid);
        BaseResponse RemoveCartItem(CartDetail cartDetail);
    }
}
