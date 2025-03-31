
using E_commerce_app.Interface;
using Hotel_booking.Interface;

namespace E_commerce_app.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }


    }
}
