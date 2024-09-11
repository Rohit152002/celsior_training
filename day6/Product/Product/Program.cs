using System.Transactions;

namespace Product
{
    internal class Program
    {
        ProductService productService;
        ICustomerService customerService;
        ISupplierService supplierService;
        IProductViewer productViewer;
        public Program()
        {
            productService = new ProductService();
            supplierService = productService;
            customerService = productService;
            productViewer = productService;

        }
        void PrintMenu()
        {
                Console.WriteLine("Customer or Supplier ");
                Console.WriteLine("1 - Customer");
                Console.WriteLine("2 - Supplier");
                Console.WriteLine("0 - Exit");
        }

        void PrintSupplier()
        {
            Console.WriteLine("\nPlease Enter ");
            Console.WriteLine("1 - Service Add New Product");
            Console.WriteLine("2 - Service Add Product Quantity");
            Console.WriteLine("3 - View All product");
            Console.WriteLine("0 - Exit");
        }

        void PrintCustomer()
        {
            Console.WriteLine("\nPlease Enter ");
            Console.WriteLine("1 - Buy Product");
            Console.WriteLine("2 - View All product");
            Console.WriteLine("0 - Exit");
        }
        void addProduct()
        {
            int supplierId;
            Console.WriteLine("Enter your supplier id");
            supplierId=Convert.ToInt32(Console.ReadLine());
            supplierService.addProduct(supplierId);
        }
        void addQuantity()
        {
            int id;
            Console.WriteLine("Enter the product id : - ");
            id=Convert.ToInt32(Console.ReadLine());
            supplierService.addProductQuantityById(id);
        }

        void buyProduct()
        {
            int customerId,productId;
            Console.WriteLine("Enter your  customer id");
            customerId=Convert.ToInt32(Console.ReadLine());
            productViewer.showAllProducts();
            customerService.buyProduct(customerId);
        }

        void SupplierInteraction()
        {
            var choice = 0;
            do
            {
                PrintSupplier();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addProduct();
                        break;
                    case 2:
                        addQuantity();
                        break;
                    case 3:
                        productViewer.showAllProducts();
                        break;

                    default:
                        Console.WriteLine("Ïnvalid option");
                        break;
                }
            } while (choice != 0);
        }

        void CustomerInteraction()
        {
            var choice = 0;
            do
            {
                PrintCustomer();
                
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        buyProduct();
                        break;
                    case 2:
                        productViewer.showAllProducts();
                        break;

                    default:
                        Console.WriteLine("Ïnvalid option");
                        break;
                }
            } while (choice != 0);
        }
        void CustomerOrSupplierInteraction(){
            var choice = 0;
            do
            {
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CustomerInteraction();
                            break;
                    case 2:
                        SupplierInteraction();
                        break;
                    case 3:
                        productViewer.showAllProducts();
                        break;

                     default:
                        Console.WriteLine("Ïnvalid option");
                        break;
                }
            } while (choice != 0);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.CustomerOrSupplierInteraction();
        }
    }
}
