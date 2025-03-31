using E_commerce_app.DTOs;
using E_commerce_app.Entities;
using E_commerce_app.Extensions;
using E_commerce_app.Interface;
using E_commerce_app.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce_app.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IOrderRepository _OrderRepository;

        public OrderController(IUnitOfWork UnitOfWork, IOrderRepository orderRepository)
        {
            _UnitOfWork = UnitOfWork;
            _OrderRepository = orderRepository;
        }
        [HttpPost("Order/Create")]
        public async Task<IActionResult> Create([FromBody] OrderDto data)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiResponseMessageDto()
                {
                    Date = { },
                    StatusCode = 400,
                    IsSuccess = false,
                    Messages = BadRequest(ModelState)
                });

            var order = await _OrderRepository.handleWithOrderDetails(data);

            var isCreated = await _UnitOfWork.Order.AddAsync(order);
            if (isCreated)
            {
                var res = await _OrderRepository.ReducesInventory(data);
                return Ok(new ApiResponseMessageDto()
                {
                    Date = null,
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }

            return Ok(new ApiResponseMessageDto()
            {
                Date = { },
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccess = false,
                Messages = HttpStatusCode.BadRequest.ToString(),
            });

        }

        [HttpGet("/Orders/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _OrderRepository.GetOrdersById(id);
                if (order == null)
                {
                    return Ok(new ApiResponseMessageDto()
                    {
                        Date = null,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        IsSuccess = false,
                        Messages = HttpStatusCode.NotFound.ToString(),
                    });

                }


                return Ok(new ApiResponseMessageDto()
                {
                    Date = order.MappingOrderDto(),
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }
            catch
            {
                return Ok(new ApiResponseMessageDto()
                {
                    Date = { },
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Messages = HttpStatusCode.BadRequest.ToString(),
                });
            }
        }

        [HttpPost("Order/UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderDto data)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiResponseMessageDto()
                {
                    Date = { },
                    StatusCode = 400,
                    IsSuccess = false,
                    Messages = BadRequest(ModelState)
                });



            var res = await _OrderRepository.UpdateOrder(data);
            if (res)
            {
                return Ok(new ApiResponseMessageDto()
                {
                    Date = null,
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }

            return Ok(new ApiResponseMessageDto()
            {
                Date = { },
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccess = false,
                Messages = HttpStatusCode.BadRequest.ToString(),
            });


        }
    }
}
