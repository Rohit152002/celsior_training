using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal interface ISupplierService
    {
        public void addProduct(int supplierId);
        public void addProductQuantityById(int productId);
    }
}
