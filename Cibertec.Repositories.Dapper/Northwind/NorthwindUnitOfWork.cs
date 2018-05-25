using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            OrderItems = new OrderItemRepository(connectionString);
            Orders = new OrderRepository(connectionString);
            Products = new ProductRepository(connectionString);
            Suppliers = new SupplierRepository(connectionString);
            Users = new UserRepository(connectionString);
        }

        public ICustomerRepository Customers { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
