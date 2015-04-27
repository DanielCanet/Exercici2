using exercici2.original.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.model
{
    class OrderByCreditCard:OrderBase
    {
        public PaymentGatewayWrapper paymentGatewayWrapper { get; set; }

        public OrderByCreditCard()
        {
            paymentGatewayWrapper = new PaymentGatewayWrapper();
        }

        public void Checkout(PaymentDetails paymentDetails, Cart cart)
        {

            if (ChargeCard(paymentDetails, cart))
            {
                ReserveInventory(cart);

            }          

        }

        public bool ChargeCard(PaymentDetails paymentDetailsCart, Cart cart)
        {

            return paymentGatewayWrapper.Charge(paymentDetailsCart, cart);
            
            //using (var paymentGateway = new PaymentGateway())
            //{
                //try
                //{
                //    paymentGateway.Credentials = "account credentials";
                //    paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
                //    paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
                //    paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
                //    paymentGateway.NameOnCard = paymentDetails.CardholderName;
                //    paymentGateway.AmountToCharge = cart.TotalAmount;

                //    paymentGateway.Charge();
                //}
                //catch (AvsMismatchException ex)
                //{
                //    throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
                //}
                //catch (Exception ex)
                //{
                //    throw new OrderException("There was a problem with your card.", ex);
                //}
            //}
        }
    }
}
