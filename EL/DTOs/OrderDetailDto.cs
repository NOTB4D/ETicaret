using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.DTOs
{
    public class OrderDetailDto: IDto
    {
        public int OrderNumber { get; set; }
        public int Status { get; set; }
        public string Massage { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
    }
}
