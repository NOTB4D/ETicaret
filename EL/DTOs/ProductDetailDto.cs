using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.DTOs
{
   public class ProductDetailDto: IDto
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double UnitInStock { get; set; }
        public string BrandName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public List<string> ProductImages { get; set; }



    }
}
