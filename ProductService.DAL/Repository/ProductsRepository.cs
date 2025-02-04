using Microsoft.EntityFrameworkCore;
using ProductService.DAL.Data;
using ProductService.DAL.Model;
using ProductService.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.DAL.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
           Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
           int affectedRowsCount = await _context.SaveChangesAsync();
            return affectedRowsCount>0;
        }

        public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _context.Products.FirstOrDefaultAsync(conditionExpression);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _context.Products.Where(conditionExpression).ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            Product? existingProduct = await _context.Products.FirstOrDefaultAsync(product => product.ProductId == product.ProductId);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Category = product.Category;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.QuantityInStock = product.QuantityInStock;

            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
