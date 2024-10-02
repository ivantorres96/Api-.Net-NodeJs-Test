using Prueba.Models.DTOs.Universals;
using Prueba.Models.Models;

namespace Prueba.Domains.Interfaces
{
    public interface IProductDomain
    {
        Task<UniversalResponseDto<bool>> CreateProduct(ProductsModel product);

        Task<UniversalResponseDto<bool>> UpdateProduct(ProductsModel product);

        Task<UniversalResponseDto<List<ProductsModel>>> GetProducts();

        Task<UniversalResponseDto<ProductsModel>> GetProductById(int id);

        Task<UniversalResponseDto<bool>> DeleteProduct(int id);
    }
}
