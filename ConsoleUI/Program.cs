using BL.Concrete;
using DAL.Concrate.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll() )
            {
                Console.WriteLine(product.Uadi);
            }
        }
    }
}
