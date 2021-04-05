using System;
using System.Threading.Tasks;
using AutoFixture;
using GameStore.BLL.Contracts;
using GameStore.BLL.Implementation;
using GameStore.DataAccess.Contracts;
using GameStore.Domain;
using GameStore.Domain.Models;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace GameStore.BLL.Tests.Unit
{
    [TestFixture]
    public class OrderCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_AllValidationSucceed_CreateOrder()
        {
            // Arrange
            var order = new OrderUpdateModel();
            var expected = new Order();

            var gameGetService = new Mock<IGameGetService>();
            gameGetService.Setup(x => x.ValidateAsync(order));

            var customerGetService = new Mock<ICustomerGetService>();
            customerGetService.Setup(x => x.ValidateAsync(order));

            var orderDataAccess = new Mock<IOrderDataAccess>();
            orderDataAccess.Setup(x => x.InsertAsync(order)).ReturnsAsync(expected);

            var orderCreateService = new OrderCreateService(orderDataAccess.Object, gameGetService.Object, customerGetService.Object);


            // Act
            var result = await orderCreateService.CreateAsync(order);


            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_GameValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var order = new OrderUpdateModel();
            var expected = fixture.Create<string>();

            var gameGetService = new Mock<IGameGetService>();
            gameGetService.Setup(x => x.ValidateAsync(order)).Throws(new InvalidOperationException(expected));

            var customerGetService = new Mock<ICustomerGetService>();
            customerGetService.Setup(x => x.ValidateAsync(order));

            var orderDataAccess = new Mock<IOrderDataAccess>();

            var orderCreateService = new OrderCreateService(orderDataAccess.Object, gameGetService.Object, customerGetService.Object);

            // Act
            var action = new Func<Task>(() => orderCreateService.CreateAsync(order));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            orderDataAccess.Verify(x => x.InsertAsync(order), Times.Never);
        }

        [Test]
        public async Task CreateAsync_CustomerValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var order = new OrderUpdateModel();
            var expected = fixture.Create<string>();

            var gameGetService = new Mock<IGameGetService>();
            gameGetService.Setup(x => x.ValidateAsync(order));

            var customerGetService = new Mock<ICustomerGetService>();
            customerGetService.Setup(x => x.ValidateAsync(order)).Throws(new InvalidOperationException(expected));

            var orderDataAccess = new Mock<IOrderDataAccess>();

            var orderCreateService = new OrderCreateService(orderDataAccess.Object, gameGetService.Object, customerGetService.Object);

            // Act
            var action = new Func<Task>(() => orderCreateService.CreateAsync(order));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            orderDataAccess.Verify(x => x.InsertAsync(order), Times.Never);
        }
    }
}