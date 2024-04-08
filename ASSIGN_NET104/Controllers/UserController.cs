using ASSIGN_Data.Models;
using ASSIGN_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASSIGN_NET104.Controllers
{
    public class UserController : Controller
    {
        ASSIGNMENT_NET104Context context;
        AllRepositories<User> userRepos;
        AllRepositories<GioHang> gioHangRepos;

        public UserController()
        {
            context = new ASSIGNMENT_NET104Context();
            userRepos = new AllRepositories<User>(context, context.Users);
            gioHangRepos = new AllRepositories<GioHang>(context, context.GioHangs);
        }

        public IActionResult Index()
        {
            var data = context.Users.Include(a => a.Role).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            var role = context.Roles.ToList();
            ViewBag.Role = new SelectList(role, "Id", "VaiTro");

            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = Guid.NewGuid();
            userRepos.CreateObj(user);

            var gioHang = new GioHang()
            {
                Id_User = user.Id,
                TongTien = 0
            };

            gioHangRepos.CreateObj(gioHang);

            return RedirectToAction("Login");
        }

        public IActionResult Update(Guid id)
        {
            var user = userRepos.GetByID(id);

            var role = context.Roles.ToList();
            ViewBag.Roles = new SelectList(role, "Id", "VaiTro");

            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            userRepos.UpdateObj(user);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var user = userRepos.GetByID(id);
            userRepos.DeleteObj(user);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var user = userRepos.GetByID(id);

            var role = context.Roles.ToList();
            ViewBag.Roles = new SelectList(role, "Id", "VaiTro");

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Lấy ra user có thông tin trùng với username và password được nhập vào
            var loginData = userRepos.GetAll().FirstOrDefault(p => p.TenDN == username && p.MatKhau == password);
            if (loginData == null)
            {
                return Content("Đăng nhập thất bại");
            }
            else
            {
                HttpContext.Session.SetString("user", loginData.Id.ToString());
                TempData["Username"] = username;
                return RedirectToAction("IndexKH", "SanPham");
            }
        }
    }
}
