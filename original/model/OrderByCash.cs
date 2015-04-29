using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exercici2.original.services;

namespace exercici2.original.model
{
    class OrderByCash : OrderBase
    {

        public OrderByCash(): base(new InventorySystemWrapper()){}

        public override bool Checkout(Cart cart)
        {
            return ReserveInventory(cart);
        }
    }
}
