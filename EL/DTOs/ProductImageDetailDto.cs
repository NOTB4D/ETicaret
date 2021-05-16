using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.DTOs
{
    public class ProductImageDetailDto : IDto
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
         public int SubCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
         public string ProductImage { get; set; }



    }
}
