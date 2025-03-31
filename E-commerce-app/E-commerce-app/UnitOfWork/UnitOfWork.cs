

using E_commerce_app.Data;
using E_commerce_app.Interface;
using E_commerce_app.Services;

namespace E_commerce_app.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly DataContext _context;
        public ICustomerRepository Customer { get; }
        public IOrderRepository Order { get; }

        public UnitOfWorks(DataContext context)
        {
            _context = context;
            Customer = new CustomerRepository(context);
            Order = new OrderRepository(context);

        }

    }
}
