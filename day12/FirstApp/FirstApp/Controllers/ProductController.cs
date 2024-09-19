using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
	public class ProductController : Controller
	{
		List<Product> products = new List<Product> { new Product { Id = 1, Name = "Book", Description = "Book1 Description", Image = "https://media.gettyimages.com/id/157482029/photo/stack-of-books.jpg?s=612x612&w=gi&k=20&c=_Yaofm8sZLZkKs1eMkv-zhk8K4k5u0g0fJuQrReWfdQ=", Price = 100, Quantity = 1 }, new Product { Id = 2, Name = "Book2", Description = "Book2 Description", Image = "https://images.pexels.com/photos/159866/books-book-pages-read-literature-159866.jpeg?cs=srgb&dl=pexels-pixabay-159866.jpg&fm=jpg", Price = 200, Quantity = 3 } };

		public IActionResult Index()
		{
			return View(products);
		}
	}
}
