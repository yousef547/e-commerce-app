using E_commerce_app.DTOs;
using E_commerce_app.Extensions;
using E_commerce_app.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_commerce_app.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CustomerController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        [HttpPost("Customer/Create")]
        public async Task<IActionResult> Create([FromBody] CustomerDto data)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiResponseMessageDto()
                {
                    Date = { },
                    StatusCode = 400,
                    IsSuccess = false,
                    Messages = BadRequest(ModelState)
                });

            var customer = data.MappingCustomer();
            var isCreated = await _UnitOfWork.Customer.AddAsync(customer);
            if (isCreated)
            {
                return Ok(new ApiResponseMessageDto()
                {
                    Date = customer,
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

        [HttpGet("Customer")]
        public async Task<IActionResult> Get()
        {
            try
            {

                var data = await _UnitOfWork.Customer.GetAllAsync();

                return Ok(new ApiResponseMessageDto()
                {
                    Date = data.Select(x => x.MappingCustomerDto()),
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


        [HttpGet("/Customers/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var data = await _UnitOfWork.Customer.FindByIdAsync(id);
                if(data == null)
                {
                    return Ok(new ApiResponseMessageDto()
                    {
                        Date =null,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        IsSuccess = false,
                        Messages = HttpStatusCode.NotFound.ToString(),
                    });

                }
                return Ok(new ApiResponseMessageDto()
                {
                    Date = data.MappingCustomerDto(),
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
    }
}
