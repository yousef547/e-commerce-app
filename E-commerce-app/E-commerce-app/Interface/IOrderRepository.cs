﻿using E_commerce_app.DTOs;
using E_commerce_app.Entities;
using Hotel_booking.Interface;
using System.Reflection.Metadata;

namespace E_commerce_app.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> handleWithOrderDetails(OrderDto data);
        Task<bool> ReducesInventory(OrderDto data);
        Task<bool> UpdateOrder(UpdateOrderDto data);
        Task<Order> GetOrdersById(int id);


    }
}
