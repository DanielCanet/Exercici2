namespace exercici2.original.model
{
    //Solo es util para tarjetas
    public class PaymentDetails
    {
        public PaymentMethod PaymentMethod { get; set; }

        public string CreditCardNumber { get; set; }

        public string ExpiresMonth { get; set; }

        public string ExpiresYear { get; set; }

        public string CardholderName { get; set; }
    }
}