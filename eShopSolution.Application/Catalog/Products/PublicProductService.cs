using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;

        public PublicProductService(EShopDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join cat in _context.Categories on pic.CategoryId equals cat.Id
                        select new { p, pt, pic, cat };

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(x => request.CategoryId == x.pic.CategoryId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Name = x.pt.Name,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }
                ).ToListAsync();
            return new PagedViewModel<ProductViewModel>() { Items = data, TotalPage = totalRow };
        }
    }
}