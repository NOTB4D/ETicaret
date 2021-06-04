using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Gecersiz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string CategoryListed = "Kategoriler Listelendi";
        public static string ProductCountofCategoryError = "Kategori Limitini Aştınız";
        public static string CategoryLimitExceded = "Kategory Limiti aşıldığı için ürün eklenemiyor";
        public static string ProductNameAlreadyExists = "Ürün Adı Mevcut";
        public static string AuthorizationDenied = "Yetkiniz Bulunmamaktadır ";
        public static string UserRegistered = "Kullanıcı Oluşturuldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Adı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string ProductImageNotFound = "Ürün Resmi Bulunamadı";
        public static string ProductImageCountExceeded = "Resim Limiti Aşıldığı için Resim Eklenemiyor";
        public static string ProductImageAdded = "Ürün Resmi Başarıyla Eklendi";
        public static string ProductImageMustBeExists = "Ürün Resmi Mutlaka Olmalı";
        public static string ProductHaveNoImage = "Ürün Resmi Bulunmamaktadır";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string CustomerUpdated = "Müsteri Bilgileri Güncellendi";
        public static string AddressAdded = "Adres Eklendi";
        public static string AddressDeleted = "Adres Silindi";
        public static string AddressListed = "Adressler Listelendi";

        public static object BrandAdded = "Marka Eklendi";
        public static string BrandListed = "Marklar Listelendi";

        public static string CategoryAlreadyExist = "Bu isimde kategori mevcut";

        public static string SubCategoryAdded = "Alt KAtegory Eklendi";

        public static string productDeleted = "Ürün Resmi Silindi";
        public static string productImageUpdated = "Ürün Resmi Güncellendi";

        public static string PaySuccess = "Ödemeniz Başarı ile Tamamlandı";

        public static string CityAdd = "Şehir Başarıyla Eklendi";
        public static string payError = "Ödemeniz hatalı";
    }
}
