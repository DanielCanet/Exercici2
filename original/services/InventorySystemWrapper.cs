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

            return result;
        }
    }
}
