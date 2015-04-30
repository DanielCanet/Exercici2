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
        public ILoggerWrapper loggerWrapper { get; set; }
        public PaymentDetails paymentDetails { get; set; }

        public OrderOnline(ILoggerWrapper loggerWrapper, PaymentDetails paymentDetails)
            : base(new PaymentGatewayWrapper(), new PaymentDetails())
        {
            this.loggerWrapper = loggerWrapper;
            this.paymentDetails = paymentDetails;
        }

        public override bool Checkout(Cart cart)
        {

            return NotifyCustomer(cart);

        }

        private bool NotifyCustomer(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
            bool result = false;
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
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        //Fallara siempre
                        //Logger.Error("Problem sending notification email", ex);
                        loggerWrapper.Error(ex);
                        result = false;
                    }
                }
            }
            return result;
        }
    }
}
