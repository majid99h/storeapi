using Core.Domain;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
   public interface IShipmentRepository
    {
        BaseResponse SaveShipment(Shipment ship);
    }
}
