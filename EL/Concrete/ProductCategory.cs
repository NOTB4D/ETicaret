using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.Concrete
{
    public class ProductCategory: IEntity
    {
        public int ProductCategoryId { get; set; }
        public int UrunId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
