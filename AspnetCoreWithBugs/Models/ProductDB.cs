﻿using Microsoft.EntityFrameworkCore;
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
        
        public async static Task<Product> RetrieveProductAsync(ProductContext _context, int id)
        {
            Product product = await _context
                .Products
                .Where(prod => prod.ProductId == id)
                .SingleAsync();

            return product;
        }

        public async static Task<Product> EditProductAsync(ProductContext _context, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            // _context.Update(product);
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
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
