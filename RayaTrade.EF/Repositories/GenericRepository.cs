using Microsoft.EntityFrameworkCore;
using RayaTrade.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected  Context _context;

        public GenericRepository(Context _context)
        {
            this._context = _context;
        }

        public void Delete(T Entity)
        {
           _context.Set<T>().Remove(Entity);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T Entity)
        {
            _context.Set<T>().Add(Entity);
        }

        public void Update(T Entity)
        {
            _context.Update(Entity);
        }
    }
}
