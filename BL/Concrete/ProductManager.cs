using BL.Abstract;
using DAL.Abstract;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            // iş kodları varsa yaz
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            return _productDal.GetAll(p => p.Id == Id);
        }
    }
}
