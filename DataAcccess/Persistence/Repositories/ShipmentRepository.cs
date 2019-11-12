using Core.Domain;
using Core.Helper;
using Core.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence.Repositories
{
    public class ShipmentRepository : Repository<Shipment> ,IShipmentRepository
    {
        public ShipmentRepository(StoreDBContext context) : base(context)
        {}
        public BaseResponse SaveShipment(Shipment shipment)
        {
            var response = new BaseResponse();
            try
            {
                this._dbContext.Shipment.Add(shipment);
                this._dbContext.SaveChanges();
                response.status = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public StoreDBContext _dbContext
        {
            get { return Context as StoreDBContext; }
        }
    }
}
