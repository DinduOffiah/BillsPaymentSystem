using Microsoft.AspNetCore.Mvc;
using BillsPaymentSystem.API.DTO;
using BillsPaymentSystem.Core.BillerAgents;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillsPaymentSystem.API.Controllers;
using BillsPaymentSystem.DAL.Models;

namespace BillsPaymentSystem.API.Tests
{
    public class BillsControllerTests
    {
        [Fact]
        public async Task ListBills_ReturnsOk_WhenBillsExist()
        {
            // Arrange
            var mockServices = new Mock<IBillerAgent>();
            var bills = new List<Bill>
            {
                new Bill { BillID = 1, BillName = "Electricity", Amount = 100 },
                new Bill { BillID = 2, BillName = "Water", Amount = 50 }
            };
            mockServices.Setup(s => s.GetBills()).ReturnsAsync(bills);
            var controller = new BillsController(mockServices.Object);

            // Act
            var result = await controller.ListBills();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var billsDto = Assert.IsAssignableFrom<IEnumerable<BillDto>>(okResult.Value);
            Assert.Equal(2, billsDto.Count());
        }

        [Fact]
        public async Task ListBills_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var mockServices = new Mock<IBillerAgent>();
            mockServices.Setup(s => s.GetBills()).ThrowsAsync(new Exception("Some error"));
            var controller = new BillsController(mockServices.Object);

            // Act
            var result = await controller.ListBills();

            // Assert
            var serverErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, serverErrorResult.StatusCode);
            Assert.Equal("An error occurred while processing the request.", serverErrorResult.Value);
        }
    }
}
