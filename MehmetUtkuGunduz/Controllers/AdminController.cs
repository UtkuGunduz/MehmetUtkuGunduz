using MehmetUtkuGunduz.Models;
using MehmetUtkuGunduz.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MehmetUtkuGunduz.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly AppDbContext _context;

        public AdminController(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            int totalMemberCount = _userManager.Users.Count();
            ViewBag.TotalMemberCount = totalMemberCount;

            int estateCount = _context.Estates.Count();
            ViewBag.EstateCount = estateCount;

            int nonAdminMemberCount = _roleManager.Roles.Count(m => m.Name == "Üye");
            ViewBag.NonAdminMemberCount = nonAdminMemberCount;

            int adminMemberCount = _roleManager.Roles.Count(m => m.Name == "Admin");
            ViewBag.AdminMemberCount = adminMemberCount;


            return View();
        }

        public IActionResult Blank()
        {
            return View();
        }
        public IActionResult Buttons()
        {
            return View();
        }
        public IActionResult Flot()
        {
            return View();
        }
        public IActionResult Forms()
        {
            return View();
        }
        public IActionResult Grid()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Morris()
        {
            return View();
        }
        public IActionResult Notifications()
        {
            return View();
        }
        public IActionResult PanelsWells()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
        public IActionResult Typography()
        {
            return View();
        }
        public async Task<IActionResult> Members()
        {
            var users = await _userManager.Users.ToListAsync();

            var userModels = new List<UserModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                var userModel = new UserModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = roleName
                };

                userModels.Add(userModel);
            }

            return View(userModels);
        }

        public async Task<IActionResult> Roles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAdd(AppRole model)
        {
            var role = await _roleManager.FindByNameAsync(model.Name);
            if (role == null)
            {

                var newrole = new AppRole();
                newrole.Name = model.Name; ;
                await _roleManager.CreateAsync(newrole);
            }
            return RedirectToAction("Roles");
        }
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult CategoryListAjax()
        {
            var CategoryModels = _context.Categories.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return Json(CategoryModels);
        }

        public IActionResult CategoryByIdAjax(int id)
        {
            var CategoryModel = _context.Categories.Where(s => s.Id == id).Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).SingleOrDefault();

            return Json(CategoryModel);
        }

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

