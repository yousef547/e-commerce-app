using E_commerce_app.DTOs;
using E_commerce_app.Entities;

namespace E_commerce_app.Extensions
{
    public static class OrderExtations
    {
        public static OrderProduct MappingOrder(this Product orderDetails, OrderDto data)
        {
            return new OrderProduct
            {
                Price = (double)orderDetails.Price * data.OrderDetails.Where(x => x.ProductId == orderDetails.Id).FirstOrDefault().Quantity,
                Quantity = data.OrderDetails.Where(x => x.ProductId == orderDetails.Id).FirstOrDefault().Quantity,
                ProductId = orderDetails.Id
            };
        }


        public static RetrieveOrderDetailDto MappingOrderDetails(this OrderProduct orderDetails)
        {
            return new RetrieveOrderDetailDto
            {
                Id = orderDetails.Id,
                ProductId = orderDetails.ProductId,
                Price = orderDetails.Price,
                ProductName = orderDetails.Product.Name,
                Quantity = orderDetails.Quantity
            };
        }



        public static RetrieveOrderDto MappingOrderDto(this Order order)
        {
            return new RetrieveOrderDto
            {
                Id = order.Id,
                Status = order.Status,
                CutomerName = order.Customer.Name,
                products = order.OrderProducts.Select(x => x.MappingOrderDetails()).ToList()
            };
        }
    }
}
