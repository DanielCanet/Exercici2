namespace exercici2.original.services
{
    public class InventorySystem
    {
        public void Reserve(string sku, int quantity)
        {
            throw new InsufficientInventoryException();
        }
    }
}