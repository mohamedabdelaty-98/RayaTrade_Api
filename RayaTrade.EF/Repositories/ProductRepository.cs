using RayaTrade.Core.Interfaces;
using RayaTrade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.EF.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProduct
    {
        private readonly Context _context;
        public ProductRepository(Context _context) : base(_context)
        {
            this._context = _context;
        }
        public IEnumerable<Product> FindAll(Expression<Func<Product, bool>> predicate)
        {
            return _context.products.Where(predicate).ToList();
        }
    }
}
