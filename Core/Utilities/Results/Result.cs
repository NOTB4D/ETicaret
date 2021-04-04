using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
      
        // :this() yaparsan iki parametre yollarsan bu calışır
        public Result(bool succsess, string mesage):this(succsess)
        {
            Message = mesage;
           
        }
        // Tek parametre yollarsan bu calışır 
        public Result (bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
