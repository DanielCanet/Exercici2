using System.Security.Authentication.ExtendedProtection;
using exercici2.original.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace exercici2.original.model
{
    class OrderOnline:OrderByCreditCard
    {
        public LoggerWrapper loggerWrapper { get; set; }

        public OrderOnline(LoggerWrapper loggerWrapper):base(new PaymentGatewayWrapper())
        {
            this.loggerWrapper = loggerWrapper;
        }

        public void Checkout(PaymentDetails paymentDetails, Cart cart)
        {

            NotifyCustomer(cart);

        }

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
                        //Logger.Error("Problem sending notification email", ex);
                        loggerWrapper.Error(ex);
                    }
                }
            }
        }
    }
}
