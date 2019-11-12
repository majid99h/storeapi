using Core.Domain;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IOrderRepository :IRepository<Order>
    {
        BaseResponse SaveOrder(Shipment ship);
        BaseResponse GetOrders();
    }
}