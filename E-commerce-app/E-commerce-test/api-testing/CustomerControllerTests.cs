using E_commerce_app.Controllers;
using E_commerce_app.DTOs;
using E_commerce_app.Entities;
using E_commerce_app.Extensions;
using E_commerce_app.Interface;
using E_commerce_app.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_test.api_testing
{
    public class CustomerControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CustomerController _controller;

        public CustomerControllerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _controller = new CustomerController(_mockUnitOfWork.Object);
        }


        #region GetById
        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenCustomerDoesNotExist()
        {
            // Arrange
            int customerId = 1;
            _mockUnitOfWork.Setup(uow => uow.Customer.FindByIdAsync(customerId)).ReturnsAsync((Customer)null);

            // Act
            var result = await _controller.GetById(customerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<CustomerDto>>(okResult.Value);
            Assert.Equal(apiResponse.StatusCode, (int)HttpStatusCode.NotFound);
            Assert.Equal(apiResponse.IsSuccess, false);

        }

        [Fact]
        public async Task GetById_ShouldReturnBadRequest_WhenException()
        {
            // Arrange
            int customerId = 1;
            _mockUnitOfWork.Setup(uow => uow.Customer.FindByIdAsync(It.IsAny<int>())).ThrowsAsync(new System.Exception());

            // Act
            var result = await _controller.GetById(customerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<CustomerDto>>(okResult.Value);
            Assert.Equal(apiResponse.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.Equal(apiResponse.IsSuccess, false);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithItem_WhenItemExists()
        {
            // Arrange: Set up the test ID and create an Item object
            int testId = 1;
            var testItem = new Customer {  };
            _mockUnitOfWork.Setup(repo => repo.Customer.FindByIdAsync(testId)).ReturnsAsync(testItem);

            // Act: Call the method under test
            var result = await _controller.GetById(testId);

            // Assert: Verify that the result is an OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<CustomerDto>>(okResult.Value);
            Assert.Equal(apiResponse.Date.Name, testItem.Name);
        }

        #endregion

        #region GetAll

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithData_WhenCallIsSuccessful()
        {
            // Arrange
            var mockCustomers = new List<Customer>
            {
                new Customer {  },
                new Customer {  }
            };

            _mockUnitOfWork.Setup(uow => uow.Customer.GetAllAsync()).ReturnsAsync(mockCustomers);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<List<CustomerDto>>>(okResult.Value);
            Assert.True(apiResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.OK, apiResponse.StatusCode);
            Assert.NotNull(apiResponse.Date);
        }


        [Fact]
        public async Task Get_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            _mockUnitOfWork.Setup(uow => uow.Customer.GetAllAsync()).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<List<CustomerDto>>>(okResult.Value);
            Assert.False(apiResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, apiResponse.StatusCode);
            Assert.Empty(apiResponse.Date); // Expecting empty data on bad request
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_ReturnsOk_WithCreatedCustomer_WhenModelIsValid()
        {
            // Arrange
            var customerDto = new CustomerDto {};
            _mockUnitOfWork.Setup(u => u.Customer.AddAsync(It.IsAny<Customer>()))
                           .ReturnsAsync(true);
            // Act
            var result = await _controller.Create(customerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<Customer>>(okResult.Value);
            Assert.True(apiResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.OK, apiResponse.StatusCode);
            Assert.NotNull(apiResponse.Date);

        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");

            var customerDto = new CustomerDto(); // Invalid data

            // Act
            var result = await _controller.Create(customerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<Customer>>(okResult.Value);
            Assert.False(apiResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, apiResponse.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenCustomerIsNotCreated()
        {
            // Arrange
            var customerDto = new CustomerDto { /* populate with valid data */ };

            _mockUnitOfWork.Setup(u => u.Customer.AddAsync(It.IsAny<Customer>()))
                           .ReturnsAsync(false);

            // Act
            var result = await _controller.Create(customerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<Customer>>(okResult.Value);
            Assert.False(apiResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, apiResponse.StatusCode);
        }

        #endregion



    }
}
