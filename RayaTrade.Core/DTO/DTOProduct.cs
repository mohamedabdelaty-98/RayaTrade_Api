using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayaTrade.Core.DTO
{
    public class DTOProduct
    {
        public int Id { get; set; }
        [RegularExpression(@"^[^0-9].*$",ErrorMessage = "Product Name must not start with a number")]
        public string Name { get; set; }
        [RegularExpression(@"^(?![0-9])\w.*$", ErrorMessage = "Description must not start with a number and should contain at least one word.")]
        public string Description { get; set; }
        [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Quantity must be a positive integer and not zero.")]
        public int Quantity { get; set; }
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Price must be a positive number and not zero.")]
        public decimal Price { get; set; }
    }
}
