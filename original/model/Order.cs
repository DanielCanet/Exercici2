using System;
using System.Net.Mail;
using exercici2.original.services;


namespace exercici2.original.model
{
    //Inversion de dependencias
    public class Order
    {
        //Cobra online, con tarjeta y en efectivo -> Aplicar soluciones
        public void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                ChargeCard(paymentDetails, cart);
            }

            ReserveInventory(cart);

            if (notifyCustomer)
            {
                NotifyCustomer(cart);
            }
        }

        //Se deberia encapsular el contenido de este metodo?
        private void NotifyCustomer(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
            if (!String.IsNullOrEmpty(customerEmail))
            {
                using (var message = new MailMessage("orders@somewhere.com", customerEmail))
                using (var client = new SmtpClient("localhost"))
                {
                    message.Subject = "Your order placed on " + DateTime.Now.ToString();
                    message.Body = "Your order details: \n " + cart.ToString();

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Fallara siempre
                        Logger.Error("Problem sending notification email", ex);
                    }
                }
            }
        }

        private void ReserveInventory(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.Sku, item.Quantity);

                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }

        private void ChargeCard(PaymentDetails paymentDetails, Cart cart)
        {
            using (var paymentGateway = new PaymentGateway())
            {
                try
                {
                    paymentGateway.Credentials = "account credentials";
                    paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
                    paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
                    paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
                    paymentGateway.NameOnCard = paymentDetails.CardholderName;
                    paymentGateway.AmountToCharge = cart.TotalAmount;

                    paymentGateway.Charge();
                }
                catch (AvsMismatchException ex)
                {
                    throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("There was a problem with your card.", ex);
                }
            }
        }
    }
}
