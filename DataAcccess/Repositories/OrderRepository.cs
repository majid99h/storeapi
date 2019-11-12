using Core.Domain;
using Core.Helper;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDBContext context) : base(context)
        {

        }
        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }

        public BaseResponse GetOrders()
        {
            var response = new BaseResponse();
            try
            {
                response.data = this._dbContext.Order.ToList();
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

        public BaseResponse SaveOrder(Shipment shipment)
        {
            var response = new BaseResponse();
          

            using (var dBContext = new StoreDBContext())
            {
                using (var transaction = dBContext.Database.BeginTransaction())
                {
                    try
                    {
                        var cartDetail = dBContext.CartDetail.Include(x => x.Product)
                                            .Where(c => c.CartId == shipment.CartId).ToList();
                        var Order = new Order
                        {
                            OrderTotal = cartDetail.Sum(x => x.Product.Price * x.Quantity),
                            CreateDate = DateTime.Now,
                            Username = shipment.UserName
                        };
                        dBContext.Order.Add(Order);
                        dBContext.SaveChanges();
                        foreach (var item in cartDetail)
                        {

                            var orderDetail = new OrderDetail
                            {
                                ProductId = item.ProductId ?? 0,
                                Quantity = item.Quantity ?? 0,
                                Price = item.Product.Price,
                                OrderId = Order.OrderId
                            };
                            dBContext.OrderDetail.Add(orderDetail);
                            dBContext.SaveChanges();
                        }
                        shipment.ShipmentDate = DateTime.Now;
                        dBContext.Shipment.Add(shipment);
                        dBContext.SaveChanges();

                        dBContext.CartDetail.RemoveRange(cartDetail);
                        dBContext.SaveChanges();
                        Cart cart = dBContext.Cart.Where(x => x.CartId == shipment.CartId).FirstOrDefault();
                        dBContext.Cart.Remove(cart);
                        dBContext.SaveChanges();
                        transaction.Commit();
                        response.status = true;
                        return response;
                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        response.status = false;
                        response.message = ex.ToString();
                        return response;

                    }
                }
            }
        }
    }
}
