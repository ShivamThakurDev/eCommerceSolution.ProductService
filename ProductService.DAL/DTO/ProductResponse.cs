using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.DAL.DTO
{
    public record ProductResponse(Guid ProductId, string ProductName, string Category, double? UnitPrice, int? QuantityInStock)
    {
        public ProductResponse():this(default,default,default,default,default)
        {
        }
    }
}
