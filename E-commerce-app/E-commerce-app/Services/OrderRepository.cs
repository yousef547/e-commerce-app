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
            List<OrderProduct> orderDetails = selectedProduct.Select(x => x.MappingOrder(data)).ToList();
            Order order = new Order();
            order.CustomerId = data.CutomerId;
            order.OrderDate = DateTime.UtcNow;
            order.TotalPrice = orderDetails.Sum(x => x.Price);
            order.Status = GetEnumStatusDescription.GetEnumDescription(TypeStatus.Pending);
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
                updateProduct.Stock = updateProduct.Stock - item.Quantity;
            }
            _dbContext.UpdateRange(selectedProduct);
            var res = await _dbContext.SaveChangesAsync();
            return res > 0;

        }

        public async Task<bool> UpdateOrder(UpdateOrderDto data)
        {
            var order = await _dbContext.Orders.Where(x=>x.Id == data.OrderId).Include(x => x.OrderProducts).FirstOrDefaultAsync();
            var orderDetail = order.OrderProducts;
            order.Status = data.Status;


            var productIds = data.OrderDetails.Select(x => x.ProductId);
            var products = await _dbContext.Products.Where(x => productIds.Contains(x.Id)).ToListAsync();

            foreach (var item in data.OrderDetails)
            {

                var productItem = orderDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                
                var diff = item.Quantity - productItem.Quantity;
                var updateProductStock = products.Where(x => x.Id == item.ProductId).FirstOrDefault();
                updateProductStock.Stock = updateProductStock.Stock - diff;

                productItem.Quantity = item.Quantity;
                productItem.Price = item.Quantity * updateProductStock.Price;


            }
            _dbContext.Update(order);
            var res = _dbContext.SaveChanges() > 0;

            if(res)
                _dbContext.UpdateRange(products);

            return _dbContext.SaveChanges() > 0;
        }
    }
}
