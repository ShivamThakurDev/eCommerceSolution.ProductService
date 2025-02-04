using ProductService.DAL.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.DAL.DTO
{
    public record ProductAddRequest(string ProductName, CategoryOptions Category,double? UnitPrice, int? QuantityInStock)
    {
     public ProductAddRequest():this(default,default,default,default)
        {
        }
    }
}
