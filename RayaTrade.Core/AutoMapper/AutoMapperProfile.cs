using AutoMapper;
using RayaTrade.Core.DTO;
using RayaTrade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, DTOProduct>();
            CreateMap<DTOProduct, Product>();
        }
    }
}
