using MehmetUtkuGunduz.Models;
using System.ComponentModel.DataAnnotations;

namespace MehmetUtkuGunduz.ViewModels
{
    public class EstateModel

    {
        public int Id { get; set; }


        [Required(ErrorMessage = "İlan Başlığı Giriniz!")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Şehir Adı Giriniz!")]
        public string City { get; set; }


        [Required(ErrorMessage = "İlçe Adı Giriniz!")]
        public string District { get; set; }


        [Required(ErrorMessage = "Mahalle Adı Giriniz!")]
        public string Neighbourhood { get; set; }


        [Required(ErrorMessage = "Kategori Seçiniz!")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Kategori Giriniz!")]
        public Category Category { get; set; }


        [Required(ErrorMessage = "Konut Tipi Giriniz!")]
        public string ResidentialType { get; set; }


        [Required(ErrorMessage = "Fiyat Giriniz!")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Metrekare Bilgisi Giriniz!")]
        public decimal SquareMeters { get; set; }


        [Required(ErrorMessage = "Oda Sayısı Giriniz!")]
        public int NumberOfRooms { get; set; }


        [Required(ErrorMessage = "Banyo Sayısı Giriniz!")]
        public int NumberOfBathrooms { get; set; }


        [Required(ErrorMessage = "Binanın Kat Sayısını Giriniz!")]
        public int NumberOfBuildingFloors { get; set; }


        [Required(ErrorMessage = "Kat Bilgisi Giriniz!")]
        public int FloorNumber { get; set; }


        [Required(ErrorMessage = "Krediye Uygunluk Bilgisi Giriniz!")]
        public bool CreditEligibility { get; set; }


        [Required(ErrorMessage = "Tapu Bilgisi Giriniz!")]
        public string TitleDeedStatus { get; set; }


        [Required(ErrorMessage = "Kullanım Durumu Bilgisi Giriniz!")]
        public string UsageStatus { get; set; }


        [Required(ErrorMessage = "Isınma Tipi Giriniz!")]
        public string HeatingType { get; set; }


        [Required(ErrorMessage = "Eşya Durumu Bilgisi Giriniz!")]
        public string FurnitureStatus { get; set; }


        [Required(ErrorMessage = "Site Bilgisi Giriniz!")]
        public bool PropertyLocation { get; set; }


        [Required(ErrorMessage = "Cephe Bilgisi Giriniz!")]
        public string Aspect { get; set; }


        [Required(ErrorMessage = "İnşa Yılı Giriniz!")]
        public int ConstructionYear { get; set; }

        [Required(ErrorMessage = "Fotoğraf URL'si Giriniz!")]
        public string ImageUrlName { get; set; }

        [Required(ErrorMessage = "Fotoğraf URL'si Giriniz!")]
        public Image ImageUrl { get; set; }

        [Required(ErrorMessage = "Fotoğraf URL'si Giriniz!")]
        public string VideoUrlName { get; set; }

        [Required(ErrorMessage = "Video URL'si Giriniz!")]
        public Video VideoUrl { get; set; }


        [Required(ErrorMessage = "İlan Sahibi Bilgisi Giriniz!")]
        public string ListingOwner { get; set; }


        [Required(ErrorMessage = "Telefon Numarası Giriniz!")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "E-Posta Adresi Giriniz!")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "İlan Tarihi Giriniz!")]
        public DateTime ListingDate { get; set; }


        [Required(ErrorMessage = "İlan Güncelleme Tarihi Giriniz!")]
        public DateTime UpdateDate { get; set; }


        [Required(ErrorMessage = "Durum Bilgisi Giriniz!")]
        public bool Status { get; set; }


        [Required(ErrorMessage = "İlgili Arama Sözcükleri Giriniz!")]
        public string Keywords { get; set; }


        [Required(ErrorMessage = "Bahçe Bilgisi Giriniz!")]
        public bool HasGarden { get; set; }


        [Required(ErrorMessage = "Asansör Bilgisi Giriniz!")]
        public bool HasElevator { get; set; }


        [Required(ErrorMessage = "Balkon Bilgisi Giriniz!")]
        public bool HasBalcony { get; set; }


        [Required(ErrorMessage = "Otopark Bilgisi Giriniz!")]
        public bool HasParking { get; set; }


        [Required(ErrorMessage = "Kablosuz Ağ Giriniz!")]
        public bool HasWifi { get; set; }
    }
}
