using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWithBugs.Models
{
    public static class ProductDB
    {
        public async static Task<Product> CreateProductAsync(ProductContext _context, Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
        
        public async static Task<Product> EditProductIdAsync(ProductContext _context, int id)
        {
            var product = await _context.Products.FindAsync(id);
            await _context.SaveChangesAsync();

            return product;
        }

        public async static Task<Product> EditProductAsync(ProductContext _context, Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async static Task<Product> DeleteProductAsync(ProductContext _context, int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);

            return product;
        }

        public async static Task<Product> DeleteProductConfirmAsync(ProductContext _context, int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.Products.SingleAsync();

            return product;
        }
    }
}
