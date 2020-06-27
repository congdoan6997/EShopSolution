using eShopSolution.Data.EF;
using eShopSolution.Utilities;
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

        public async Task<List<ProductViewModel>> GetAll(string languageId)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        where pt.LanguageId == languageId
                        select new { p, pt };

            //int totalRow =  await query.CountAsync();
            return await query.Select(x => new ProductViewModel()
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
                ViewCount = x.p.ViewCount,
                LanguageId = languageId
            }
                ).ToListAsync();
            //return new PagedViewModel<ProductViewModel>() { Items = data, TotalPage = Math.Round( totalRow/re };
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join cat in _context.Categories on pic.CategoryId equals cat.Id
                        // join l in _context.Languages on pt.LanguageId equals l.Id
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
                    ViewCount = x.p.ViewCount,
                    LanguageId = x.pt.LanguageId
                }
                ).ToListAsync();
            return new PagedViewModel<ProductViewModel>() { Items = data, TotalPage = totalRow };
        }

        public async Task<ProductViewModel> GetById(int productId, string languageId)
        {
            var pro = await _context.Products.FindAsync(productId);
            if (pro == null)
            {
                throw new EShopException($"Don't find product with id: {productId}");
            }
            var protra = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);
            if (protra == null)
            {
                throw new EShopException($"Don't find product language with id: {languageId}");
            }
            return new ProductViewModel()
            {
                Id = pro.Id,
                DateCreated = pro.DateCreated,
                Description = protra.Description,
                Details = protra.Details,
                SeoAlias = protra.SeoAlias,
                SeoDescription = protra.SeoDescription,
                SeoTitle = protra.SeoTitle,
                Price = pro.Price,
                OriginalPrice = pro.OriginalPrice,
                Name = protra.Name,
                Stock = pro.Stock,
                ViewCount = pro.ViewCount,
                LanguageId = protra.LanguageId
            };
        }
    }
}