using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {


        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.ImagePath).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.Caption).HasMaxLength(200);
            builder.HasOne(p => p.Product).WithMany(i => i.ProductImages).HasForeignKey(p => p.ProductId);
        }
    }
}
