using Core.Utilities.Results;
using EL.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
   public interface ICarouselImageService
    {
        IResult Add(IFormFile file, CarouselImage  carouselImage);
        IResult Delete(int Id);
        IResult Update(IFormFile file, CarouselImage  carouselImage);
        IDataResult<CarouselImage> Get(int Id);
        IDataResult<List<CarouselImage>> GetAll();
        IDataResult<List<CarouselImage>> GetImageBycarouselId(int Id);
    } 
}
