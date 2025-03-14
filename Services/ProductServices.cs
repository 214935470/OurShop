﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entits;
using Repository;

namespace Services
{
    public class ProductServices : IProductServices
    {
        IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

 
        public async Task<List<Product>> GetProduct(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await productRepository.GetProduct(position, skip, desc, minPrice, maxPrice, categoryIds);
        }









    }
}
