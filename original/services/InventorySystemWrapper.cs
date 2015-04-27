using exercici2.original.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercici2.original.services
{
    class InventorySystemWrapper
    {

        public InventorySystem inventorySystem { get; set; }

        public InventorySystemWrapper()
        {
            this.inventorySystem = new InventorySystem();
        }

        public bool Reserve(OrderItem item)
        {
            var result = true;

            try
            {
                this.inventorySystem.Reserve(item.Sku, item.Quantity);
            }
            catch (Exception e)
            {
                result = false;
            }
            //catch (InsufficientInventoryException ex)
            //{
            //    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
            //    result = false;

            //}
            //catch (Exception ex)
            //{
            //    throw new OrderException("Problem reserving inventory", ex);
            //    result = false;
            //}
            return result;
        }
    }
}
