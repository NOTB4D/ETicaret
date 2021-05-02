using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.DTOs
{
   public  class ProductImageDto :IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string SubCategoryName { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
