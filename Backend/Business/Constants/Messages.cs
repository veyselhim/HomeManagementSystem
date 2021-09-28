using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business
{
    public class Messages
    {
        public static string DuesPaymentAdded = "Ödeme alındı";
        public static string DuesPaymentUpdated = "Ödeme güncellendi";
        public static string DuesPaymentDeleted = "Ödeme silindi";
        public static string DuesPaymentShown = "Ödeme gösterildi";

        public static string ApartmentAdded = "Konut eklendi";
        public static string ApartmentUpdated = "Konut güncellendi";
        public static string ApartmentDeleted = "Konut silindi";
        public static string ApartmentShown = "Konut gösterildi";


        public static string DuesAdded = "Aidat gönderildi";
        public static string DuesUpdated = "Aidat güncellendi";
        public static string DuesDeleted = "Aidat silindi";
        public static string DuesShown = "Aidat gösterildi";

        public static string MessageAdded = "Mesaj gönderildi";
        public static string MessageUpdated = "Mesaj güncellendi";
        public static string MessageDeleted = "Mesaj silindi";
        public static string MessageShown = "Mesaj gösterildi";

        public static string BillAdded = "Fatura gönderildi"; 
        public static string BillUpdated = "Fatura güncellendi";
        public static string BillDeleted = "Fatura silindi";
        public static string BillShown = "Fatura gösterildi";

        public static string CardAdded = "Kart eklendi";
        public static string CardUpdated = "Kart güncellendi";
        public static string CardDeleted = "Kart silindi";
        public static string CardShown = "Kart gösterildi";

        public static string BillPaymentAdded = "Fatura ödendi";
        public static string BillPaymentDeleted = "Fatura silindi";
        public static string BillPaymentUpdated = "Fatura güncellendi";
        public static string BillPaymentShown = "Fatura gösterildi";
        public static string ResidentAlreadyExists = "Bu kişiye ait zaten başka konut var";
        public static string AuthorizationDenied = "Yetkisiz kullanıcı!";

        public static string UserShown = "Kullanıcı gösterildi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string SuccesfulLogin = "Giriş başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var";

        public static string PasswordError = "Şifre yanlış";

        public static string TokenAdded = "Token oluşturuldu";

        public static string UserOperationClaimAdded="Rol ataması başarıyla tamamlandı";
        public static string UserOperationClaimDeleted = "Rol ataması başarıyla silindi";
    }
}
