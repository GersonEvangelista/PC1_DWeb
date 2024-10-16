using repasito_DOMAIN.Core.DTO;
using repasito_DOMAIN.Data;
using repasito_DOMAIN.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasito_DOMAIN.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ProductsDTO>> GetProductsDTO()
        {
            var productos = await _productsRepository.GetProducts();
            var productosDTO = new List<ProductsDTO>();

            foreach (var product in productos)
            {
                var productDTO = new ProductsDTO();
                productDTO.IdProduct = product.IdProduct;
                productDTO.ProductName = product.ProductName;
                productDTO.IdCategory = product.IdCategory;
                productosDTO.Add(productDTO);
            }

            return productosDTO;
        }

        public async Task<ProductsDTO> GetProductById(int id)
        {
            var product = await _productsRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }

            var ProductDTO = new ProductsDTO();

            ProductDTO.IdProduct = product.IdProduct;
            ProductDTO.ProductName = product.ProductName;
            ProductDTO.IdCategory = product.IdCategory;
    
            return ProductDTO;
        }

        public async Task<int> Insert(ProductsDTO productDTO)
        {
            var product = new Products();
            product.IdProduct = productDTO.IdProduct;
            product.ProductName = productDTO.ProductName;
            int id = await _productsRepository.Insert(product);
            return id;

        }

        public async Task<bool> Update(ProductsDTO productDTO)
        {
            var product = new Products();
            product.IdProduct = productDTO.IdProduct;
            product.ProductName = productDTO.ProductName;
            bool resp = await _productsRepository.Update(product);
            return resp;
        }

        public async Task<bool> Delete(int id)
        {
            var cat = await _productsRepository.Delete(id);
            return cat;
        }

    }
}
