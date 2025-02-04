using ProductService.DAL.DTO;
using ProductService.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.BLL.Service.IService
{
    public interface IProductService
    {
        Task<List<ProductResponse?>> GetProducts();
        Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);
        Task<ProductResponse?> AddProduct(ProductAddRequest productRequest);
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productRequest);
        Task<bool> DeleteProduct(Guid productId);
    }
}
