using MehmetUtkuGunduz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MehmetUtkuGunduz.ViewModels;
using NuGet.ContentModel;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MehmetUtkuGunduz.Controllers
{
	public class EstateController : Controller
	{
		private readonly AppDbContext _context;

		public EstateController(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}


		public IActionResult Index(string searchText = "", int page = 1, int size = 6)
		{
			var estates = _context.Estates.Where(s => s.Title.ToLower().Contains(searchText.ToLower())).AsQueryable();

			int pageskip = (page - 1) * size;
			var estateModels = estates.Skip(pageskip).Take(size).Select(x => new EstateModel()
			{
				Id = x.Id,
				Title = x.Title,
				City = x.City,
				District = x.District,
				Neighbourhood = x.Neighbourhood,
				Category = x.Category,
				ResidentialType = x.ResidentialType,
				Price = x.Price,
				SquareMeters = x.SquareMeters,
				NumberOfRooms = x.NumberOfRooms,
				NumberOfBathrooms = x.NumberOfBathrooms,
				NumberOfBuildingFloors = x.NumberOfBuildingFloors,
				FloorNumber = x.FloorNumber,
				CreditEligibility = x.CreditEligibility,
				TitleDeedStatus = x.TitleDeedStatus,
				UsageStatus = x.UsageStatus,
				HeatingType = x.HeatingType,
				FurnitureStatus = x.FurnitureStatus,
				PropertyLocation = x.PropertyLocation,
				Aspect = x.Aspect,
				ConstructionYear = x.ConstructionYear,
				ImageUrl = x.ImageUrl,
				VideoUrl = x.VideoUrl,
				ListingOwner = x.ListingOwner,
				PhoneNumber = x.PhoneNumber,
				EmailAddress = x.EmailAddress,
				ListingDate = x.ListingDate,
				UpdateDate = x.UpdateDate,
				Status = x.Status,
				Keywords = x.Keywords,
				HasGarden = x.HasGarden,
				HasElevator = x.HasElevator,
				HasBalcony = x.HasBalcony,
				HasParking = x.HasParking,
				HasWifi = x.HasWifi
			}).ToList();
			int recordCount = estates.Count();
			int pageCount = (int)Math.Ceiling(Convert.ToDecimal(recordCount / size));


			ViewBag.PageCount = pageCount;
			ViewBag.RecordCount = recordCount;
			ViewBag.Page = page;
			ViewBag.Size = size;
			ViewBag.SearchText = searchText;

			return View(estateModels);
		}
		public IActionResult Detail(int id)
		{
			var estateModel = _context.Estates.Select(x => new EstateModel()
			{
				Id = x.Id,
				Title = x.Title,
				City = x.City,
				District = x.District,
				Neighbourhood = x.Neighbourhood,
				Category = x.Category,
				ResidentialType = x.ResidentialType,
				Price = x.Price,
				SquareMeters = x.SquareMeters,
				NumberOfRooms = x.NumberOfRooms,
				NumberOfBathrooms = x.NumberOfBathrooms,
				NumberOfBuildingFloors = x.NumberOfBuildingFloors,
				FloorNumber = x.FloorNumber,
				CreditEligibility = x.CreditEligibility,
				TitleDeedStatus = x.TitleDeedStatus,
				UsageStatus = x.UsageStatus,
				HeatingType = x.HeatingType,
				FurnitureStatus = x.FurnitureStatus,
				PropertyLocation = x.PropertyLocation,
				Aspect = x.Aspect,
				ConstructionYear = x.ConstructionYear,
				ImageUrl = x.ImageUrl,
				VideoUrl = x.VideoUrl,
				ListingOwner = x.ListingOwner,
				PhoneNumber = x.PhoneNumber,
				EmailAddress = x.EmailAddress,
				ListingDate = x.ListingDate,
				UpdateDate = x.UpdateDate,
				Status = x.Status,
				Keywords = x.Keywords,
				HasGarden = x.HasGarden,
				HasElevator = x.HasElevator,
				HasBalcony = x.HasBalcony,
				HasParking = x.HasParking,
				HasWifi = x.HasWifi

			}).SingleOrDefault(x => x.Id == id);
			return View(estateModel);

		}
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Insert(EstateModel model)
		{
			var estate = new Estate();
			estate.Title = model.Title;
			estate.City = model.City;
			estate.District = model.District;
			estate.Neighbourhood = model.Neighbourhood;
			estate.Category = model.Category;
			estate.ResidentialType = model.ResidentialType;
			estate.Price = model.Price;
			estate.SquareMeters = model.SquareMeters;
			estate.NumberOfRooms = model.NumberOfRooms;
			estate.NumberOfBathrooms = model.NumberOfBathrooms;
			estate.NumberOfBuildingFloors = model.NumberOfBuildingFloors;
			estate.FloorNumber = model.FloorNumber;
			estate.CreditEligibility = model.CreditEligibility;
			estate.TitleDeedStatus = model.TitleDeedStatus;
			estate.UsageStatus = model.UsageStatus;
			estate.HeatingType = model.HeatingType;
			estate.FurnitureStatus = model.FurnitureStatus;
			estate.PropertyLocation = model.PropertyLocation;
			estate.Aspect = model.Aspect;
			estate.ConstructionYear = model.ConstructionYear;
			estate.ImageUrl = model.ImageUrl;
			estate.VideoUrl = model.VideoUrl;
			estate.ListingOwner = model.ListingOwner;
			estate.PhoneNumber = model.PhoneNumber;
			estate.EmailAddress = model.EmailAddress;
			estate.ListingDate = model.ListingDate;
			estate.UpdateDate = model.UpdateDate;
			estate.Status = model.Status;
			estate.Keywords = model.Keywords;
			estate.HasGarden = model.HasGarden;
			estate.HasElevator = model.HasElevator;
			estate.HasBalcony = model.HasBalcony;
			estate.HasParking = model.HasParking;
			estate.HasWifi = model.HasWifi;

			_context.Estates.Add(estate);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var estateModel = _context.Estates.Select(x => new EstateModel()
			{
				Id = x.Id,
				Title = x.Title,
				City = x.City,
				District = x.District,
				Neighbourhood = x.Neighbourhood,
				Category = x.Category,
				ResidentialType = x.ResidentialType,
				Price = x.Price,
				SquareMeters = x.SquareMeters,
				NumberOfRooms = x.NumberOfRooms,
				NumberOfBathrooms = x.NumberOfBathrooms,
				NumberOfBuildingFloors = x.NumberOfBuildingFloors,
				FloorNumber = x.FloorNumber,
				CreditEligibility = x.CreditEligibility,
				TitleDeedStatus = x.TitleDeedStatus,
				UsageStatus = x.UsageStatus,
				HeatingType = x.HeatingType,
				FurnitureStatus = x.FurnitureStatus,
				PropertyLocation = x.PropertyLocation,
				Aspect = x.Aspect,
				ConstructionYear = x.ConstructionYear,
				ImageUrl = x.ImageUrl,
				VideoUrl = x.VideoUrl,
				ListingOwner = x.ListingOwner,
				PhoneNumber = x.PhoneNumber,
				EmailAddress = x.EmailAddress,
				ListingDate = x.ListingDate,
				UpdateDate = x.UpdateDate,
				Status = x.Status,
				Keywords = x.Keywords,
				HasGarden = x.HasGarden,
				HasElevator = x.HasElevator,
				HasBalcony = x.HasBalcony,
				HasParking = x.HasParking,
				HasWifi = x.HasWifi

			}).SingleOrDefault(x => x.Id == id);
			return View(estateModel);
		}

		[HttpPost]
		public IActionResult Edit(EstateModel model)
		{
			var estate = _context.Estates.SingleOrDefault(x => x.Id == model.Id);
			estate.Title = model.Title;
			estate.City = model.City;
			estate.District = model.District;
			estate.Neighbourhood = model.Neighbourhood;
			estate.Category = model.Category;
			estate.ResidentialType = model.ResidentialType;
			estate.Price = model.Price;
			estate.SquareMeters = model.SquareMeters;
			estate.NumberOfRooms = model.NumberOfRooms;
			estate.NumberOfBathrooms = model.NumberOfBathrooms;
			estate.NumberOfBuildingFloors = model.NumberOfBuildingFloors;
			estate.FloorNumber = model.FloorNumber;
			estate.CreditEligibility = model.CreditEligibility;
			estate.TitleDeedStatus = model.TitleDeedStatus;
			estate.UsageStatus = model.UsageStatus;
			estate.HeatingType = model.HeatingType;
			estate.FurnitureStatus = model.FurnitureStatus;
			estate.PropertyLocation = model.PropertyLocation;
			estate.Aspect = model.Aspect;
			estate.ConstructionYear = model.ConstructionYear;
			estate.ImageUrl = model.ImageUrl;
			estate.VideoUrl = model.VideoUrl;
			estate.ListingOwner = model.ListingOwner;
			estate.PhoneNumber = model.PhoneNumber;
			estate.EmailAddress = model.EmailAddress;
			estate.ListingDate = model.ListingDate;
			estate.UpdateDate = model.UpdateDate;
			estate.Status = model.Status;
			estate.Keywords = model.Keywords;
			estate.HasGarden = model.HasGarden;
			estate.HasElevator = model.HasElevator;
			estate.HasBalcony = model.HasBalcony;
			estate.HasParking = model.HasParking;
			estate.HasWifi = model.HasWifi;

			_context.Estates.Update(estate);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var estateModel = _context.Estates.Select(x => new EstateModel()
			{
				Id = x.Id,
				Title = x.Title,
				City = x.City,
				District = x.District,
				Neighbourhood = x.Neighbourhood,
				Category = x.Category,
				ResidentialType = x.ResidentialType,
				Price = x.Price,
				SquareMeters = x.SquareMeters,
				NumberOfRooms = x.NumberOfRooms,
				NumberOfBathrooms = x.NumberOfBathrooms,
				NumberOfBuildingFloors = x.NumberOfBuildingFloors,
				FloorNumber = x.FloorNumber,
				CreditEligibility = x.CreditEligibility,
				TitleDeedStatus = x.TitleDeedStatus,
				UsageStatus = x.UsageStatus,
				HeatingType = x.HeatingType,
				FurnitureStatus = x.FurnitureStatus,
				PropertyLocation = x.PropertyLocation,
				Aspect = x.Aspect,
				ConstructionYear = x.ConstructionYear,
				ImageUrl = x.ImageUrl,
				VideoUrl = x.VideoUrl,
				ListingOwner = x.ListingOwner,
				PhoneNumber = x.PhoneNumber,
				EmailAddress = x.EmailAddress,
				ListingDate = x.ListingDate,
				UpdateDate = x.UpdateDate,
				Status = x.Status,
				Keywords = x.Keywords,
				HasGarden = x.HasGarden,
				HasElevator = x.HasElevator,
				HasBalcony = x.HasBalcony,
				HasParking = x.HasParking,
				HasWifi = x.HasWifi

			}).SingleOrDefault(x => x.Id == id);
			return View(estateModel);
		}

		[HttpPost]
		public IActionResult Delete(EstateModel model)
		{
			var estate = _context.Estates.SingleOrDefault(x => x.Id == model.Id);
			_context.Estates.Remove(estate);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ChangeStatus(int id, bool st)
		{
			var estate = _context.Estates.SingleOrDefault(x => x.Id == id);
			estate.Status = st;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Categories()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public IActionResult CategoryListAjax()
		{
			var CategoryModels = _context.Categories.Select(x => new CategoryModel()
			{
				Id = x.Id,
				Name = x.Name,
			}).ToList();

			return Json(CategoryModels);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult CategoryByIdAjax(int id)
		{
			var CategoryModel = _context.Categories.Where(s => s.Id == id).Select(x => new CategoryModel()
			{
				Id = x.Id,
				Name = x.Name,
			}).SingleOrDefault();

			return Json(CategoryModel);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult CategoryAddEditAjax(CategoryModel model)
		{
			var categoryResult = new CategoryResultModel();
			if (model.Id == 0)
			{
				var Category = new Category();
				Category.Name = model.Name;
				_context.Categories.Add(Category);
				_context.SaveChanges();
				categoryResult.Message = "Kategori Eklendi";
			}
			else
			{
				var Category = _context.Categories.FirstOrDefault(x => x.Id == model.Id);
				Category.Name = model.Name;
				_context.SaveChanges();
				categoryResult.Message = "Kategori Güncellendi";
			}

			return Json(categoryResult);
		}

		[Authorize(Roles = "Admin")]
		public IActionResult CategoryRemoveAjax(int id)
		{
			var Category = _context.Categories.FirstOrDefault(x => x.Id == id);
			_context.Categories.Remove(Category);
			_context.SaveChanges();

			var categoryResult = new CategoryResultModel();
			categoryResult.Message = "Kategori Silindi";
			return Json(categoryResult);
		}
	}
}
