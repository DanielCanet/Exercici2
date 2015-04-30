using exercici2.original.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.services
{
    public interface IPaymentGatewayWrapper
    {
        PaymentGateway paymentGateway { get; set; }
        bool Charge(PaymentDetails paymentDetails, Cart cart);
    }
}
