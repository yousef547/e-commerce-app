using E_commerce_app.Data;
using E_commerce_app.Entities;
using E_commerce_app.Interface;
using tasky.Services;

namespace E_commerce_app.Services
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {

        }
    }
}
