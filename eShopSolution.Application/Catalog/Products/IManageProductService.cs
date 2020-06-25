using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace eShopSolution.Application.catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task AddViewCount(int productId);

        Task<bool> UpdateStock(int productId, int quantity);

        Task<PagedViewModel<ProductViewModel>> GetAllPaging(GetMaganeProductPagingRequest request);

        //Task<int> AddImages(int productId, List<IFormFile> files);
        //Task<int> RemoveImage(int imageId);
        //Task<int> UpdateImage(int imageId, string caption, bool isDefault);
        //Task<List<ProductImageViewModel>> GetProductImages();
    }
}