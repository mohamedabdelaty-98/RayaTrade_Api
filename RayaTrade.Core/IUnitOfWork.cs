using RayaTrade.Core.Interfaces;
using RayaTrade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IProduct Products { get; }
        int Save();
    }
}
