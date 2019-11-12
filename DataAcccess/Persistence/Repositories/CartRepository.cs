using Core.Domain;
using Core.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Helper;
using System.Data.SqlClient;
using Core.ViewModel;

namespace Core.Persistence.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(StoreDBContext context)
            : base(context)
        {

        }
        public IEnumerable<CartDetailVm> GetCartDetailById(string cartid)
        {
            try
            {
                var param = new SqlParameter("@cartid", cartid);
                return this._dbContext.CartDetailModel.FromSql("SpCartDetail @cartid", param).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public BaseResponse AddToCart(CartDetail cartDetail)
        {
            var response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(cartDetail.CartId))
                {
                    var cart = new Cart();
                    cart.CartId = Guid.NewGuid().ToString();
                    cart.CreateDate = DateTime.Now;
                    this._dbContext.Cart.Add(cart);
                    this._dbContext.SaveChanges();
                    cartDetail.CartId = cart.CartId;
                    response.data = cartDetail.CartId;
                }
                var entity = this._dbContext.CartDetail.Where(x => x.ProductId == cartDetail.ProductId && x.CartId == cartDetail.CartId).AsNoTracking().FirstOrDefault();
                if (entity != null)
                {

                    if (cartDetail.Quantity == 1)
                    {
                        entity.Quantity = entity.Quantity + 1;
                        
                        Update(entity);
                    }
                    else
                    {
                        entity.Quantity = entity.Quantity - 1;
                        Update(entity);
                    }

                }
                else
                {
                    cartDetail.Quantity = 1;
                    this._dbContext.Add(cartDetail);
                    this._dbContext.SaveChanges();
                }



               
                response.Total = CartCount(cartDetail.CartId);
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

        public BaseResponse RemoveCartItem(CartDetail cartDetail)
        {
            var response = new BaseResponse();
            try
            {
                if (!string.IsNullOrEmpty(cartDetail.CartId))
                {
                    var _cartDetail=  _dbContext.CartDetail.Where(x => x.ProductId == cartDetail.ProductId && x.CartId == cartDetail.CartId).FirstOrDefault();
                    _dbContext.Remove(_cartDetail);
                    _dbContext.SaveChanges();
                }
               
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
        public decimal CartCount(string cartid)
        {
            if (!string.IsNullOrEmpty(cartid))
            {
                return this._dbContext.CartDetail.Where(x => x.CartId == cartid).Sum(s => s.Quantity ?? 0);
            }
            return 0;
        }
        private void Update(dynamic entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            this._dbContext.CartDetail.Update(entity);
            this._dbContext.SaveChanges();
        }
        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }
    }
}
