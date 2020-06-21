using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(_ => new { _.CategoryId, _.ProductId });
            builder.HasOne(pr => pr.Product).WithMany(p => p.ProductInCategories).HasForeignKey(pr => pr.ProductId);
            builder.HasOne(pr => pr.Category).WithMany(p => p.ProductInCategories).HasForeignKey(pr => pr.CategoryId);
        }
    }
}