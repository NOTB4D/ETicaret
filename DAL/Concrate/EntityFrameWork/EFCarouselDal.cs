using Core.DataAccess.EntityFramework;
using DAL.Abstract;
using EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrate.EntityFrameWork
{
   public class EFCarouselDal : EfEntityRepositoryBase<CarouselImage, EcommerceContext>, ICarouselImageDal
    {
        public bool IsExist(int Id)
        {
            using (EcommerceContext context = new EcommerceContext())
            {
                return context.CarouselImages.Any(p => p.Id == Id);
            }
        }

    }
}
