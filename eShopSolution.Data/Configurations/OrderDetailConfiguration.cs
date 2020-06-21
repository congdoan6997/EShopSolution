using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(d => new { d.ProductId, d.OrderId });
            builder.HasOne(p => p.Product).WithMany(d => d.OrderDetails).HasForeignKey(p => p.ProductId);
            builder.HasOne(o => o.Order).WithMany(d => d.OrderDetails).HasForeignKey(o => o.OrderId);

        }
    }
}
