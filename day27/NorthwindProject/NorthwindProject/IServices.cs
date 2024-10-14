using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject
{
    internal interface IServices
    {
        public void Login();
        public void Register();
        public string AskCustomerID();
        public void ViewPreviousOrder(string id);

        public void GetShipperDetails();

        public void ViewOrderSummary();

        public void UpdatePassword(string username);


    }
}
