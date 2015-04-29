using exercici2.original.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.model
{
    abstract class OrderBase
    {
        public InventorySystemWrapper inventorySystemWrapper { get; set; }

        public OrderBase(InventorySystemWrapper inventorySystemWrapper)
        {
            this.inventorySystemWrapper = inventorySystemWrapper;
        }

        public abstract bool Checkout(Cart cart);


        public bool ReserveInventory(Cart cart)

        {
            var result = false;
            foreach (var item in cart.Items)
            {

                result = inventorySystemWrapper.Reserve(item);

            }

            return result;
        }
    }
}
