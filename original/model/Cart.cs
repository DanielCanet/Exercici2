using System.Collections.Generic;

namespace exercici2.original.model
{
    //NO modificar
    public class Cart
    {
        public decimal TotalAmount { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }

        public string CustomerEmail { get; set; }
    }
}