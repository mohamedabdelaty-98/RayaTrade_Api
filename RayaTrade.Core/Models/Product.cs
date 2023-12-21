using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(1500)")]
        public string Description { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
