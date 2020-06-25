using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedViewModel<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    }
}