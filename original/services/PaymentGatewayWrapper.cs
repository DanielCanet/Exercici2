using exercici2.original.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.services
{
    class PaymentGatewayWrapper
    {
        public PaymentGateway paymentGateway { get; set; }

        public PaymentGatewayWrapper()
        {
            this.paymentGateway = new PaymentGateway();
        }

        public bool Charge(PaymentDetails paymentDetails, Cart cart)
        {
        //using (var paymentGateway = new PaymentGateway())
        //{
            try
            {
                this.paymentGateway.Credentials = "account credentials";
                this.paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
                this.paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
                this.paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
                this.paymentGateway.NameOnCard = paymentDetails.CardholderName;
                this.paymentGateway.AmountToCharge = cart.TotalAmount;

                this.paymentGateway.Charge();
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
       }
    }
}
