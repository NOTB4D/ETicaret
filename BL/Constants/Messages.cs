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
    }
}
