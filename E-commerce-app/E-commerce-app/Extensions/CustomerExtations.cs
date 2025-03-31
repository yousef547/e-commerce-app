using E_commerce_app.DTOs;
using E_commerce_app.Entities;

namespace E_commerce_app.Extensions
{
    public static class CustomerExtations
    {
        public static Customer MappingCustomer(this CustomerDto customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email
            };
        }

        public static CustomerDto MappingCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email
            };
        }
    }
}
