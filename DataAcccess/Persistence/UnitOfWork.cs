using Core.Domain;
using Core.Persistence.Repositories;
using Core.Repositories;

namespace Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDBContext _context;

        public UnitOfWork(StoreDBContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            Category = new CategoryRepository(_context);
            Cart = new CartRepository(_context);
            Shipment = new ShipmentRepository(_context);
            Order = new OrderRepository(_context);
            User = new UserRepository(_context);
        }

        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICartRepository Cart { get; private set; }
        public IShipmentRepository Shipment { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IUserRepository User { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}