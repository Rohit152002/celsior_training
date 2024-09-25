using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>
        {
            new Product {Id=1, Image="1.jpg", Name="SportsBike", Quantity=1, Price=2000},
            new Product {Id=2, Image="2.jpg", Name="SportsBike", Quantity=6, Price=2000},

        };
        public ProductController()
        {
            
        }

        public IActionResult Index()
        {
            Console.WriteLine("flasl;djfk");
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = products.FirstOrDefault(x => x.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            Product oldProduct = products.FirstOrDefault(p => p.Id == id);
            oldProduct.Name = product.Name;
            oldProduct.Quantity = product.Quantity;
            oldProduct.Image = "/images/" + product.Image;
            oldProduct.Price = product.Price;


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int pid)
        {
            Product product = products.FirstOrDefault(p => p.Id == pid);
            return View(product);
        }

        [HttpDelete]
        public IActionResult Delete(int pid, Product product)
        {
            Product oldproduct = products.FirstOrDefault(p => p.Id == pid);
            products.Remove(oldproduct);
            return RedirectToAction("Index");
        }

    }
}
