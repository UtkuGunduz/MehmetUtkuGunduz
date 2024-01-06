using Microsoft.AspNetCore.Mvc;
using MehmetUtkuGunduz.Models;
using MehmetUtkuGunduz.ViewModels;

namespace MehmetUtkuGunduz.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ToDoListAjax()
        {
            var ToDoModels = _context.ToDos.Select(x => new ToDoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).ToList();

            return Json(ToDoModels);
        }
        public IActionResult ToDoByIdAjax(int id)
        {
            var ToDoModel = _context.ToDos.Where(s => s.Id == id).Select(x => new ToDoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).SingleOrDefault();

            return Json(ToDoModel);
        }
        public IActionResult ToDoAddEditAjax(ToDoModel model)
        {
            var sonuc = new SonucModel();
            if (model.Id == 0)
            {
                var ToDo = new ToDo();
                ToDo.Title = model.Title;
                ToDo.Status = model.Status;
                _context.ToDos.Add(ToDo);
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Eklendi";
            }
            else
            {
                var ToDo = _context.ToDos.FirstOrDefault(x => x.Id == model.Id);
                ToDo.Status = model.Status;
                ToDo.Title = model.Title;
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Güncellendi";
            }

            return Json(sonuc);
        }
        public IActionResult ToDoRemoveAjax(int id)
        {
            var ToDo = _context.ToDos.FirstOrDefault(x => x.Id == id);
            _context.ToDos.Remove(ToDo);
            _context.SaveChanges();

            var sonuc = new SonucModel();
            sonuc.Status = true;
            sonuc.Message = "İşlem Silindi";
            return Json(sonuc);
        }
    }
}
