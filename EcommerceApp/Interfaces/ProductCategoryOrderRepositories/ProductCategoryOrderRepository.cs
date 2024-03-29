﻿using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories
{
    public class ProductCategoryOrderRepository : IProductCategoryOrderRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<ProductCategoryOrderVM> GetAllProductCategoriesOrders()
        {
            var products = _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.ProductOrders)
                    .ThenInclude(po => po.Order)
                        .ThenInclude(o => o.User)
                .Select(p => new ProductCategoryOrderVM
                {
                    Product = p,
                    Category = p.ProductCategories.Select(pc => pc.Category).FirstOrDefault(),
                    Order = p.ProductOrders.Select(po => po.Order).FirstOrDefault()
                }).ToList();

            return products;
        }
    }
}
