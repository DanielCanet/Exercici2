using exercici2.original.model;

namespace exercici2.original.services
{
    interface IinventorySystemWrapper
    {
        InventorySystem inventorySystem { get; set; }
        bool Reserve(OrderItem item);
    }
}
