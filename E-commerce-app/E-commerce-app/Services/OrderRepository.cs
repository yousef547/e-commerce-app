using E_commerce_app.Data;
using E_commerce_app.DTOs;
using E_commerce_app.Entities;
using E_commerce_app.Extensions;
using E_commerce_app.Helpers;
using E_commerce_app.Interface;
using Hotel_booking.Helpers;
using Microsoft.EntityFrameworkCore;
using tasky.Services;

namespace E_commerce_app.Services
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {

        }

        public async Task<RetrieveOrderDto> GetOrdersById(int id)
        {
            var orders = await _dbContext.Orders.Where(x => x.Id == id).Include(x => x.Customer)
                 .Include(x => x.OrderProducts).ThenInclude(c => c.Product).FirstOrDefaultAsync();
            return orders.MappingOrderDto();
        }

        public async Task<bool> handleWithOrderDetails(OrderDto data)
        {
            var productIds = data.OrderDetails.Select(x => x.ProductId);
            var selectedProduct = await _dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();
            List<OrderItem> orderDetails = selectedProduct.Select(x => x.MappingOrder(data)).ToList();
            Order order = new Order();
            order.CustomerId = data.CutomerId;
            order.OrderDate = DateTime.UtcNow;
            order.Status = GetEnumStatusDescription.GetEnumDescription(TypeStatus.Pending);
            order.OrderStatus = CreateOrderStatus(order);
            order.OrderProducts = orderDetails;
            var isCreated = await _dbContext.AddAsync(order);
            return await _dbContext.SaveChangesAsync() > 0;

        }

        public async Task<bool> ReducesInventory(OrderDto data)
        {
            var productIds = data.OrderDetails.Select(x => x.ProductId);
            var selectedProduct = await _dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();
            foreach (var item in data.OrderDetails)
            {
                var updateProduct = selectedProduct.Where(x => x.Id == item.ProductId).FirstOrDefault();
                updateProduct.StockQuantity = updateProduct.StockQuantity - item.Quantity;
            }
            _dbContext.UpdateRange(selectedProduct);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;

        }

        public async Task<bool> UpdateOrder(UpdateOrderDto data)
        {
            var order = await _dbContext.Orders.Where(x=>x.Id == data.OrderId).FirstOrDefaultAsync();
            order.Status = data.Status;
            order.OrderStatus = CreateOrderStatus(order);
            _dbContext.Update(order);
            return _dbContext.SaveChanges() > 0;
        }

        private List<OrderStatus> CreateOrderStatus(Order order)
        {

            var orderStatus = new List<OrderStatus>();
            orderStatus.Add(new OrderStatus
            {
                OrderId = order.Id,
                Status = order.Status,
                TimeStamp = DateTime.Now,
            });
            return orderStatus;
        }
    }
}
