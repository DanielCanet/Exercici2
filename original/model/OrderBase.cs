using exercici2.original.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.model
{
    class OrderBase
    {
        public InventorySystemWrapper inventorySystemWrapper { get; set; }

        public OrderBase(InventorySystemWrapper inventorySystemWrapper)
        {
            this.inventorySystemWrapper = inventorySystemWrapper;
        }

        public bool Checkout(Cart cart)
        {
            return ReserveInventory(cart);
        }

        public bool ReserveInventory(Cart cart)

        {
            var result = false;
            foreach (var item in cart.Items)
            {

                //ENVUELVO EL SERVICIO DE INVENTARIO EN UN WRAPPER
                //try
                //{
                    //HACEMOS EL NEW EN EL CONSTRUCTOR
                //    var inventorySystem = new InventorySystem();
                result = inventorySystemWrapper.Reserve(item);

                //}
                //catch (InsufficientInventoryException ex)
                //{
                //    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                //}
                //catch (Exception ex)
                //{
                //    throw new OrderException("Problem reserving inventory", ex);
                //}
                //
            }

            return result;
        }
    }
}
