using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Security.Policy;

namespace MehmetUtkuGunduz.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ResidentialType { get; set; }
        public decimal Price { get; set; }
        public decimal SquareMeters { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfBuildingFloors { get; set; }
        public int FloorNumber { get; set; }
        public bool CreditEligibility { get; set; }
        public string TitleDeedStatus { get; set; }
        public string UsageStatus { get; set; }
        public string HeatingType { get; set; }
        public string FurnitureStatus { get; set; }
        public bool PropertyLocation { get; set; }
        public string Aspect { get; set; }
        public int ConstructionYear { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public string ListingOwner { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ListingDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public string Keywords { get; set; }
        public bool HasGarden { get; set; }
        public bool HasElevator { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasParking { get; set; }
        public bool HasWifi { get; set; }
    }
}
