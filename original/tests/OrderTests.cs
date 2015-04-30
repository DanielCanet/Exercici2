using System.Collections.Generic;
using exercici2.original.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using exercici2.original.services;
using Moq;

namespace exercici2.original.tests
{
    [TestClass]
    public class OrderTests
    {
        readonly Cart cart = new Cart
        {
            Items = new List<OrderItem>()
            {
                new OrderItem { Sku = "sku1", Quantity = 1 },
                new OrderItem { Sku = "sku2", Quantity = 3 },
            },
            TotalAmount = 4,
            CustomerEmail = "customer@somedomain.com"
        };

        [TestMethod]
        public void OriginalCashOrder()

        {
            //Arange
            var orderByCash = new OrderByCash();
            bool result = false;

            //Action
            result = orderByCash.Checkout(cart);

            //Assert
            Assert.AreEqual(true, result, "Ha habido algún proglema al realizar el pedido Online");
        }

        [TestMethod]
        public void OriginalCreditCardOrder()
        {
            var paymentDetails = new PaymentDetails
            {
                //Arange
                PaymentMethod = PaymentMethod.CreditCard,
                CreditCardNumber = "creditCardNumber",
                ExpiresMonth = "08",
                ExpiresYear = "16",
                CardholderName = "Customer Name",
            };            
            bool result = true;
            
            Mock<IPaymentGatewayWrapper> paymentGatewayWrapperMock = new Mock<IPaymentGatewayWrapper>();
            var orderByCreditCard = new OrderByCreditCard(paymentGatewayWrapperMock.Object, paymentDetails);

            //Action
            result = orderByCreditCard.Checkout(cart);

            //Assert
            Assert.AreEqual(true, result, "Ha habido algún proglema al realizar el pedido Online");
        }

        [TestMethod]
        public void OriginalOnlineOrder()
        {
            //Arrange
            var paymentDetails = new PaymentDetails
            {
                PaymentMethod = PaymentMethod.CreditCard,
                CreditCardNumber = "creditCardNumber",
                ExpiresMonth = "08",
                ExpiresYear = "16",
                CardholderName = "Customer Name",
            };
            bool result = false;

            Mock<ILoggerWrapper> loggerWrapperMock = new Mock<ILoggerWrapper>();
            var orderOnline = new OrderOnline(loggerWrapperMock.Object, paymentDetails);

            //Action
            result = orderOnline.Checkout(cart);

            //Assert
            Assert.AreEqual(true, result, "Ha habido algún proglema al realizar el pedido Online");
        }
    }
}
