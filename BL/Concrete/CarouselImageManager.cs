using BL.Abstract;
using BL.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DAL.Abstract;
using EL.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class CarouselImageManager : ICarouselImageService
    {
        ICarouselImageDal _carouselImageDal;

        public CarouselImageManager(ICarouselImageDal carouselImageDal)
        {
            _carouselImageDal = carouselImageDal;
        }
        public IResult Add(IFormFile file, CarouselImage carouselImage)
        {
            var imageCount = _carouselImageDal.GetAll(c => c.Id == carouselImage.Id).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.CarouselImageCountExceeded);
            }
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Messages);
            }
            carouselImage.ImagePath = imageResult.Messages;
            _carouselImageDal.Add(carouselImage);
            return new SuccessResult(Messages.CarouselImageAdded);
        }

        public IResult Delete(int Id)
        {
            var image = _carouselImageDal.Get(c => c.Id == Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductHaveNoImage);
            }
            FileHelper.Delete(image.ImagePath);
            _carouselImageDal.Delete(Get(Id).Data);
            return new SuccessResult(Messages.CarouselImageDeleted);
        }

        public IDataResult<CarouselImage> Get(int Id)
        {
            return new SuccessDataResult<CarouselImage>(_carouselImageDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<CarouselImage>> GetAll()
        {
            return new SuccessDataResult<List<CarouselImage>>(_carouselImageDal.GetAll());
        }

        public IDataResult<List<CarouselImage>> GetImageBycarouselId(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfCarouselImageNull(Id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarouselImage>>(result.Messages);
            }
            return new SuccessDataResult<List<CarouselImage>>(CheckIfCarouselImageNull(Id).Data);
        }

        public IResult Update(IFormFile file, CarouselImage carouselImage)
        {
            var IsImage = _carouselImageDal.Get(c => c.Id == carouselImage.Id);
            if (IsImage == null)
            {
                return new ErrorResult(Messages.CarouselHaveNoImage);
            }
            var updatedFile = FileHelper.Update(file, IsImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Messages);
            }
            carouselImage.ImagePath = updatedFile.Messages;
            return new SuccessResult(Messages.carouselImageUpdated);
        }

        private IDataResult<List<CarouselImage>> CheckIfCarouselImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carouselImageDal.GetAll(c => c.Id == id).Any();
                if (!result)
                {
                    List<CarouselImage> carouselImage = new List<CarouselImage>();
                    carouselImage.Add(new CarouselImage {  Id = id, ImagePath = path });
                    return new SuccessDataResult<List<CarouselImage>>(carouselImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarouselImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarouselImage>>(_carouselImageDal.GetAll(c => c.Id == id).ToList());
        }
    }
}
