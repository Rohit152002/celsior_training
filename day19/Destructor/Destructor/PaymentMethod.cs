using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    public abstract class PaymentMethod
    {
        public abstract string GetPaymentMethod();
        public virtual void MakePayment(decimal amount)
        {
            Console.WriteLine($"Making payment of {amount}");
        }
    }
}
