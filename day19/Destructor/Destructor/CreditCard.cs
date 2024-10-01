using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    internal class CreditCard : PaymentMethod
    {
        public override string GetPaymentMethod()
        {
            return "Paypal";
        }

        public void MakePayment(decimal amount)

        {
            base.MakePayment(amount); // default implementation 
        }
    }
}
