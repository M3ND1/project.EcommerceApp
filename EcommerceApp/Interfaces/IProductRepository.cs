﻿using EcommerceApp.Models;
using EcommerceApp.ViewModels;

namespace EcommerceApp.Interfaces
{
    public interface IProductRepository
    {
        public ICollection<Product> GetAllProducts();
        public void CreateProduct(ProductVM productVM); //TODO change from void to bool to handle exceptions
        public Product GetProductById(int id);
        public bool UpdateProduct(int id, ProductVM productVM);
        public bool DeleteProduct(int id);
        public IEnumerable<Product> SearchByName(string name);
    }
}
