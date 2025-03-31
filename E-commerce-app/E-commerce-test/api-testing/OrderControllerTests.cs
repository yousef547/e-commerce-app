using E_commerce_app.Controllers;
using E_commerce_app.DTOs;
using E_commerce_app.Entities;
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
    public class OrderControllerTests
    {
        private readonly Mock<IOrderRepository> _mockOrderUnitOfWork;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _mockOrderUnitOfWork = new Mock<IOrderRepository>();
            _controller = new OrderController(_mockOrderUnitOfWork.Object);
        }

        #region GetById



        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenOrdertExist()
        {
            // Arrange
            int orderId = 1;
            var order = new RetrieveOrderDto { /* Initialize order properties */ };
            _mockOrderUnitOfWork.Setup(repo => repo.GetOrdersById(orderId)).ReturnsAsync(order);

            // Act
            var result = await _controller.GetOrderById(orderId) as OkObjectResult;

            // Assert
            var response = result.Value as ApiResponseMessageDto<RetrieveOrderDto>;
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenOrderDoesNotExist()
        {
            // Arrange
            int testId = 1;
            _mockOrderUnitOfWork.Setup(repo => repo.GetOrdersById(testId)).ReturnsAsync((RetrieveOrderDto)null);

            // Act
            var result = await _controller.GetOrderById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseMessageDto<RetrieveOrderDto>>(okResult.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, response.StatusCode);
            Assert.False(response.IsSuccess);


        }


        [Fact]
        public async Task GetById_ShouldReturnBadRequest_WhenException()
        {
            // Arrange
            int testId = 1;
            _mockOrderUnitOfWork.Setup(repo => repo.GetOrdersById(testId)).ThrowsAsync(new System.Exception());

            // Act
            var result = await _controller.GetOrderById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponseMessageDto<RetrieveOrderDto>>(okResult.Value);
            Assert.Equal(apiResponse.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.Equal(apiResponse.IsSuccess, false);
        }
        #endregion

        #region UpdateOrderStatus


        [Fact]
        public async Task UpdateOrderStatus_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var invalidData = new UpdateOrderDto(); // Assume this creates an invalid DTO object
            _controller.ModelState.AddModelError("Error", "Invalid data");

            // Act
            var result = await _controller.UpdateOrderStatus(invalidData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseMessageDto<Order>>(okResult.Value);
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(response.IsSuccess);
        }



        [Fact]
        public async Task UpdateOrderStatus_ReturnsOk_WhenOrderIsUpdatedSuccessfully()
        {
            // Arrange
            var validData = new UpdateOrderDto { /* set valid properties here */ };
            _mockOrderUnitOfWork.Setup(repo => repo.UpdateOrder(validData)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateOrderStatus(validData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseMessageDto<Order>>(okResult.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccess);
            Assert.Equal(HttpStatusCode.OK.ToString(), response.Messages);
        }
        [Fact]
        public async Task GetOrderById_ReturnsBadRequest_OnException()
        {
            // Arrange
            int orderId = 1;
            _mockOrderUnitOfWork.Setup(repo => repo.GetOrdersById(orderId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetOrderById(orderId) as OkObjectResult;

            // Assert
            var response = result.Value as ApiResponseMessageDto<RetrieveOrderDto>;
            Assert.NotNull(response);
            Assert.False(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var invalidData = new OrderDto(); // Assume this creates an invalid DTO object
            _controller.ModelState.AddModelError("Error", "Invalid data");

            // Act
            var result = await _controller.Create(invalidData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseMessageDto<Order>>(okResult.Value);
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            Assert.False(response.IsSuccess);
           

        }

        [Fact]
        public async Task Create_ReturnsOk_WhenOrderIsCreatedSuccessfully()
        {
            // Arrange
            var orderDto = new OrderDto(); // Provide necessary details
            _mockOrderUnitOfWork.Setup(repo => repo.handleWithOrderDetails(orderDto)).ReturnsAsync(true);
            _mockOrderUnitOfWork.Setup(repo => repo.ReducesInventory(orderDto)).ReturnsAsync(true);

            // Act
            var result = await _controller.Create(orderDto) as OkObjectResult;

            // Assert
            var response = result.Value as ApiResponseMessageDto<Order>;
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenOrderCreationFails()
        {
            // Arrange
            var orderDto = new OrderDto(); // Provide necessary details
            _mockOrderUnitOfWork.Setup(repo => repo.handleWithOrderDetails(orderDto)).ReturnsAsync(false);

            // Act
            var result = await _controller.Create(orderDto) as OkObjectResult;

            // Assert
            var response = result.Value as ApiResponseMessageDto<Order>;
            Assert.NotNull(response);
            Assert.False(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
        }
        #endregion

    }
}
