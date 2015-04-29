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

            var orderByCash = new OrderByCash();

            orderByCash.Checkout(cart);
        }

        [TestMethod]
        public void OriginalCreditCardOrder()
        {
            var paymentDetails = new PaymentDetails
            {
                PaymentMethod = PaymentMethod.CreditCard,
                CreditCardNumber = "creditCardNumber",
                ExpiresMonth = "08",
                ExpiresYear = "16",
                CardholderName = "Customer Name",
            };

            Mock<IPaymentGatewayWrapper> paymentGatewayWrapperMock = new Mock<IPaymentGatewayWrapper>();

            var orderByCreditCard = new OrderByCreditCard(paymentGatewayWrapperMock.Object, paymentDetails);

            orderByCreditCard.Checkout(cart);
        }

        [TestMethod]
        public void OriginalOnlineOrder()
        {
            var paymentDetails = new PaymentDetails
            {
                PaymentMethod = PaymentMethod.CreditCard,
                CreditCardNumber = "creditCardNumber",
                ExpiresMonth = "08",
                ExpiresYear = "16",
                CardholderName = "Customer Name",
            };

            LoggerWrapper loggerWrapper = new LoggerWrapper();

            var orderOnline = new OrderOnline(loggerWrapper, paymentDetails);

            orderOnline.Checkout(cart);
        }
    }
}
