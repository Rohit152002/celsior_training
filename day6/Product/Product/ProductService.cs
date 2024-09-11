using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class ProductService : ISupplierService,ICustomerService,IProductViewer
    {
        List<Product> products = new List<Product>();
        Supplier[] suppliers;
        Customer[] customers;
        public ProductService()
        {
            suppliers = new Supplier[3]
                {
                new Supplier("Rohit"),
                new Supplier("Johnny"),
                new Supplier("Venker")
                };
            
            customers = new Customer[3]
            {
                new Customer("John", 123456890),
                new Customer("Ankita",7932419283),
                new Customer("Dev", 7643833064)
            };

        }

        Supplier checkSupplierId(int supplierId)
        {
            Supplier supplier = null;
           for (int i = 0; i < suppliers.Length; i++)
            {
                if (suppliers[i].id == supplierId)
                {
                    supplier = suppliers[i];        
                }
            }
            return supplier;
        }
        
        void PrintSupplierDetail(Supplier supplier)
        {
           
               Console.WriteLine($"Supplier Id : {supplier.id} Name : {supplier.name},");
       
        }
        void PrintCustomerDetail(Customer customer)
        {
            Console.WriteLine($" Customer Id : {customer.id} Name : {customer.name}, Phone: {customer.phone}");

        }
        public void addProduct(int supplierId)
        {
            Supplier supplier=checkSupplierId(supplierId);
            if (supplier ==null)
            {
                return;
            }
            PrintSupplierDetail(supplier);
            Product? newProduct= new Product();
            Console.WriteLine("Enter product Name: ");
            newProduct.name =Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter product price");
            newProduct.price=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter product quantity");
            newProduct.quantity=Convert.ToInt32(Console.ReadLine());
            
            products.Add(newProduct);
            Console.WriteLine("Product Added Successfully");
        }

        public void showAllProducts()
        {
            if(products.Count ==0)
            {
                Console.WriteLine("There is no product Available");
            }
            else
            {
                Console.WriteLine("All Products");
                for(int i=0; i<products.Count;i++)
                {
                    Console.WriteLine($"Id : {products[i].id} Name : {products[i].name}, Price : {products[i].price}, Quantity : {products[i].quantity}" );
                }
            }
        }



        static Product findProduct(int productId,List<Product> products)
        {
            Product? product = null;
            for (int i=0;i<products.Count;i++)
            {
                if (products[i].id == productId)
                {
                    product = products[i];
                     break;
                }
            }
            return product;
        }

        public void addProductQuantityById(int productId)
        {
           Product product = findProduct(productId, products);
            if (product != null)
            {
                product.quantity += 1;
            }
            else return;

            Console.WriteLine($"Product Quantity is {product.quantity} for {product.name}");
        }

        Customer checkCustomerId(int customerid )
        {
            Customer customer = null;
            for(int i=0;i<customers.Length; i++)
            {
                if (customers[i].id == customerid)
                {
                    customer = customers[i];
                    break;
                }
            }
            return customer;
        }

        public void buyProduct(int customerId)
        {
            int productId;
            Customer customer = checkCustomerId(customerId);
            if (customer == null)
            {
                return;
            }
            PrintCustomerDetail(customer);
            Console.WriteLine("Enter the product id");
            productId = Convert.ToInt32(Console.ReadLine());
            Product product = findProduct(customerId, products);
    
                if (product != null)
                {
                    if(product.quantity > 0)
                    {
                        product.quantity -= 1;
                        Console.WriteLine($"{product.name} has been buy by {customer.name} ");

                    }else{
                        Console.WriteLine("Product is not available");
                        return;
                    }
                }
                else
                {
                    return;
                }
            
               
        }
    }
}
