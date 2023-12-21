using RayaTrade.Core;
using RayaTrade.Core.Interfaces;
using RayaTrade.Core.Models;
using RayaTrade.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.EF
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly Context _context;
        public IProduct Products { get; private set; }

        public UnitOfWork(Context _context)
        {
            this._context = _context;
            Products = new ProductRepository(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
