using AutoMapper;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Models.DTO;

namespace WebAPIWithDatabase.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int,Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<int,Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> AddProduct(ProductDTO product)
        {
            Product newproduct = _mapper.Map<Product>(product);
            var addedproduct = await _productRepository.Add(newproduct);
            return addedproduct.Id;
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = await _productRepository.Get(productId);
            //ProductDTO productdto = _mapper.Map<ProductDTO>(product);
            return product;
        }

        public async Task<ProductDTO> UpdateProduct(int productId, float price)
        {
            var getProduct = await _productRepository.Get(productId);
            getProduct.Price = price;
            var products = await _productRepository.Update(productId, getProduct);

            ProductDTO product= _mapper.Map<ProductDTO>(products);
            return product;
        }

        public async Task<IEnumerable<ProductDTO>> ViewAllProducts()
        {
            var products = await _productRepository.GetAll();
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return productDtos;
        }

        public async Task<bool> AddNewProduct(ProductDTO product)
        {
            var myProduct = _mapper.Map<Product>(product);
            myProduct= await _productRepository.Add(myProduct);
            return product != null;

        }
    }
}
