using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccoutApplication
{
    internal abstract class Operation
    {
        public abstract void CreateAccount();

        public abstract void CreditMoney(float money,int id);
        public abstract void WithdrawMoney (float money, int id);
        public abstract void ShowBalance(int id);

    }
}
