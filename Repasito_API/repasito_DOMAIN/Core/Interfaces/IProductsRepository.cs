using repasito_DOMAIN.Data;

namespace repasito_DOMAIN.Infraestructure.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProductById(int id);
        Task<int> Insert(Products product);
        Task<bool> Update(Products product);
        Task<bool> Delete(int id);
    }
}