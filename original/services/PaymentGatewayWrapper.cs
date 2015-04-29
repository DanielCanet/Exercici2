using exercici2.original.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.services
{
    class PaymentGatewayWrapper : IPaymentGatewayWrapper
    {
        public PaymentGateway paymentGateway { get; set; }

        public PaymentGatewayWrapper()
        {
            this.paymentGateway = new PaymentGateway();
        }

        public bool Charge(PaymentDetails paymentDetails, Cart cart)
        {

            try
            {
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
