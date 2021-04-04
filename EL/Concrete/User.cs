using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL.Concrete
{
   public class User: IEntity
    {
        [Display(Name = "Adi")]
        public string Adi { get; set; }

        [Display(Name = "Soyadi")]
        public string Soyadi { get; set; }
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [Display(Name = "TC Kimlik NO")]
        public string TCNo { get; set; }
        [Display(Name = "Telefon")]
        public long Telefon { get; set; }
        [Display(Name = "DogumTarihi")]
        public DateTime DogumTarihi { get; set; }
    }
}
