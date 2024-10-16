using repasito_DOMAIN.Core.DTO;
using repasito_DOMAIN.Data;

namespace repasito_DOMAIN.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductsDTO>> GetProductsDTO();
        Task<ProductsDTO> GetProductById(int id);
        Task<int> Insert(ProductsDTO productDTO);
        Task<bool> Delete(int id);
        Task<bool> Update(ProductsDTO productDTO);
    }
}