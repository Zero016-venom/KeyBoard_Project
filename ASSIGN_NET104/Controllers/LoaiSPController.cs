using ASSIGN_Data.Models;
using ASSIGN_Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASSIGN_NET104.Controllers
{
    public class LoaiSPController : Controller
    {
        ASSIGNMENT_NET104Context context;
        AllRepositories<LoaiSP> repos;

        public LoaiSPController()
        {
            context = new ASSIGNMENT_NET104Context();
            repos = new AllRepositories<LoaiSP>(context, context.LoaiSPs);
        }

        public IActionResult Index()
        {
            var data = repos.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoaiSP loaiSP) 
        {
            loaiSP.Id = Guid.NewGuid();
            repos.CreateObj(loaiSP);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var loaiSp = repos.GetByID(id);
            return View(loaiSp);
        }
        [HttpPost]
        public IActionResult Update(LoaiSP loaiSP)
        {
            repos.UpdateObj(loaiSP);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var loaiSp = repos.GetByID(id);
            repos.DeleteObj(loaiSp);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var loaiSp = repos.GetByID(id);

            return View(loaiSp);
        }
    }
}
