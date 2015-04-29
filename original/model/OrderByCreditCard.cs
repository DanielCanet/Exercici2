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
        public PaymentDetails paymentDetails { get; set; }

        public OrderByCreditCard(PaymentGatewayWrapper paymentGatewayWrapper, PaymentDetails paymentDetails):base(new InventorySystemWrapper())
        {
            this.paymentGatewayWrapper = paymentGatewayWrapper;
            this.paymentDetails = paymentDetails;
        }

        public override bool Checkout(Cart cart)
        {

            if (ChargeCard(cart))
            {
                return ReserveInventory(cart);

            }
            return false;
        }

        public bool ChargeCard(Cart cart)
        {

            return paymentGatewayWrapper.Charge(this.paymentDetails, cart);
            
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
