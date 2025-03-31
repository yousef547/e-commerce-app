using E_commerce_app.DTOs;
using E_commerce_app.Entities;
using E_commerce_app.Extensions;
using E_commerce_app.Interface;
using E_commerce_app.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_commerce_app.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        [HttpPost("/Customer/Create")]
        public async Task<IActionResult> Create([FromBody] CustomerDto data)
        {
            if (!ModelState.IsValid)
                return Ok(new ApiResponseMessageDto<Customer>()
                {
                    Date = new Customer(),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Messages = BadRequest(ModelState)
                });

            var customer = data.MappingCustomer();
            var isCreated = await _UnitOfWork.Customer.AddAsync(customer);
            if (isCreated)
            {
                return Ok(new ApiResponseMessageDto<Customer>()
                {
                    Date = customer,
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }

            return Ok(new ApiResponseMessageDto<Customer>()
            {
                Date = new Customer(),
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccess = false,
                Messages = HttpStatusCode.BadRequest.ToString(),
            });
        }

        [HttpGet("/Customer")]
        public async Task<IActionResult> Get()
        {
            try
            {

                var data = await _UnitOfWork.Customer.GetAllAsync();

                return Ok(new ApiResponseMessageDto<List<CustomerDto>>()
                {
                    Date = data.Select(x => x.MappingCustomerDto()).ToList(),
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }
            catch
            {
                return Ok(new ApiResponseMessageDto<List<CustomerDto>>()
                {
                    Date = new List<CustomerDto>(),
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
                    return Ok(new ApiResponseMessageDto<CustomerDto>()
                    {
                        Date = new CustomerDto(),
                        StatusCode = (int)HttpStatusCode.NotFound,
                        IsSuccess = false,
                        Messages = HttpStatusCode.NotFound.ToString(),
                    });

                }
                return Ok(new ApiResponseMessageDto<CustomerDto>()
                {
                    Date = data.MappingCustomerDto(),
                    StatusCode = (int)HttpStatusCode.OK,
                    IsSuccess = true,
                    Messages = HttpStatusCode.OK.ToString(),
                });
            }
            catch
            {
                return Ok(new ApiResponseMessageDto<CustomerDto>()
                {
                    Date = new CustomerDto(),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    IsSuccess = false,
                    Messages = HttpStatusCode.BadRequest.ToString(),
                });
            }
        }
    }
}
