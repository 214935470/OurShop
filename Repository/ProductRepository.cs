using Entits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        AdoNetManageContext _AdoNetManageContext;

        public ProductRepository(AdoNetManageContext manageDbContext)
        {
            this._AdoNetManageContext = manageDbContext;
        }

        //public async Task<Product> AddProduct(Product product)
        //{
        //    await _AdoNetManageContext.Products.AddAsync(product);
        //    await _AdoNetManageContext.SaveChangesAsync();
        //    return product;

        //}


        //public async Task UpdateProduct(int id, Product productToUpdate)
        //{
        //    productToUpdate.Id = id;

        //    _AdoNetManageContext.Products.Update(productToUpdate);

        //    await _AdoNetManageContext.SaveChangesAsync();
        //}

        public async Task<List<Product>> GetProduct()
        {
            return await _AdoNetManageContext.Products.ToListAsync();

        }

        //public async Task DeleteProduct(int id, Product productToDelete)
        //{
        //    productToDelete.Id = id;

        //    _AdoNetManageContext.Products.Remove(productToDelete);

        //    await _AdoNetManageContext.SaveChangesAsync();

        //}


    }
}
