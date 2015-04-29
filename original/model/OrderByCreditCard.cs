using exercici2.original.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.model
{
    class OrderByCreditCard:OrderBase
    {
        public IPaymentGatewayWrapper paymentGatewayWrapper { get; set; }
        public PaymentDetails paymentDetails { get; set; }

        public OrderByCreditCard(IPaymentGatewayWrapper paymentGatewayWrapper, PaymentDetails paymentDetails):base(new InventorySystemWrapper())
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
           
        }
    }
}
