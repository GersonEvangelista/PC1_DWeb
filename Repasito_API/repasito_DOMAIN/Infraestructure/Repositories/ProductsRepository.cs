using Microsoft.EntityFrameworkCore;
using repasito_DOMAIN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasito_DOMAIN.Infraestructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ChaevContext _chaevContext;

        public ProductsRepository(ChaevContext chaevContext)
        {
            _chaevContext = chaevContext;
        }


        //GET
        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _chaevContext.Products.ToListAsync();
        }

        //GET BY ID
        public async Task<Products> GetProductById(int id)
        {
            var product = await _chaevContext
                .Products
                .Where(c => c.IdProduct == id)
                .FirstOrDefaultAsync();
            return product;
        }

        //Post
        public async Task<int> Insert(Products product)
        {
            await _chaevContext.Products.AddAsync(product);
            int rows = await _chaevContext.SaveChangesAsync();

            return rows > 0 ? product.IdProduct : -1;
        }

        //PUT
        public async Task<bool> Update(Products product)
        {
            _chaevContext.Products.Update(product);
            int rows = await _chaevContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete 
        public async Task<bool> Delete(int id)
        {
            var product = await _chaevContext
                            .Products
                            .FirstOrDefaultAsync(c => c.IdProduct == id);

            if (product == null) return false;

            _chaevContext.Products.Remove(product);
            int rows = await _chaevContext.SaveChangesAsync();
            return (rows > 0);
        }

    }

    

}
