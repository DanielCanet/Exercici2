using System.Collections.Generic;
using exercici2.original.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using exercici2.original.services;

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
            //NO ES NECESARIO EN LA COMPRA EN EFECTIVO
            //var cashPaymentDetails = new PaymentDetails
            //{
            //    PaymentMethod = PaymentMethod.Cash,
            //    CreditCardNumber = string.Empty,
            //    ExpiresMonth = string.Empty,
            //    ExpiresYear = string.Empty,
            //    CardholderName = string.Empty,
            //};

            InventorySystemWrapper inventorySystemWrapper = new InventorySystemWrapper();

            var orderBase = new OrderBase(inventorySystemWrapper);

            orderBase.Checkout(cart);
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

            PaymentGatewayWrapper paymentGatewayWrapper = new PaymentGatewayWrapper();

            var orderByCreditCard = new OrderByCreditCard(paymentGatewayWrapper);

            orderByCreditCard.Checkout(paymentDetails, cart);
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

            var orderOnline = new OrderOnline(loggerWrapper);

            orderOnline.Checkout(paymentDetails, cart);
        }
    }
}
