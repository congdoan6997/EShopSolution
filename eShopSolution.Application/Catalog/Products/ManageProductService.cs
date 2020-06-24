using eShopSolution.Application.catalog.Products;
using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;

        public ManageProductService(EShopDbContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Add 1 count view product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task AddViewCount(int productId)
        {
            var pro = await _context.Products.FindAsync(productId);
            pro.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var item = new Product()
            {
                Price = request.Price,
                Stock = request.Stock,
                OriginalPrice = request.OriginalPrice,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                         Name  = request.Name,
                         Description = request.Description,
                         SeoAlias = request.SeoAlias,
                         SeoDescription = request.SeoDescription,
                         SeoTitle = request.SeoTitle,
                         Details = request.Details,
                          LanguageId = request.LanguageId
                    }
                }
            };
            await _context.Products.AddAsync(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var pro = await _context.Products.FindAsync(productId);
            if (pro == null)
            {
                throw new EShopException($"Don't find product by id: {productId}");
            }
            _context.Products.Remove(pro);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join cat in _context.Categories on pic.CategoryId equals cat.Id
                        select new { p, pt, pic, cat };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(x => request.CategoryIds.Contains(x.pic.CategoryId));
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

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            var pt = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id);
            if (product == null || pt == null)
            {
                throw new EShopException($"Dont find product with id: {request.Id}");
            }
            pt.Name = request.Name;
            pt.SeoAlias = request.SeoAlias;
            pt.SeoDescription = request.SeoDescription;
            pt.SeoTitle = request.SeoTitle;
            pt.Description = request.Description;
            pt.Details = request.Details;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                throw new EShopException($"Dont find product with id: {productId}");
            }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                throw new EShopException($"Dont find product with id: {productId}");
            }
            product.Stock += quantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}