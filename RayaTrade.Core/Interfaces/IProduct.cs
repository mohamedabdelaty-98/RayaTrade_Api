using RayaTrade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core.Interfaces
{
    public interface IProduct:IGenericRepository<Product>
    {
        IEnumerable<Product> FindAll(Expression<Func<Product, bool>> predicate);
    }
}
