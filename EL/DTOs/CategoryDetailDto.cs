using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.DTOs
{
   public class CategoryDetailDto: IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double UnitInStock { get; set; }
        public int CategorId { get; set; }
    }
}
