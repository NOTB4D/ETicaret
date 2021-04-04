using BL.Abstract;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using EL.DTOs;
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

        public IResult Add(Product product)
        {
            // Business codes
            if (product.Uadi.Length<2)
            {
                return new ErrorResult("Ürün İsmi minumum 2 karakter olmalıdır");
            }
            _productDal.Add(product);
            return new SuccsessResult();
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

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.Id == productId);
           
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
