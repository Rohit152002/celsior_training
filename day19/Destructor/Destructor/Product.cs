namespace Destructor
{
    internal class Product
    {

        public float Price { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public static Product operator +(Product product1, Product product2)
        {
            Product product = new Product();
            product.Name = product1.Name; 
            product.Id = product1.Id;
            product.Price = product1.Price + product2.Price;
            return product;
        }
        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Price: $" + Price;
        }
    }
}