using ASSIGN_Data.Models;
using ASSIGN_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASSIGN_NET104.Controllers
{
	public class GioHangChiTietController : Controller
	{
		ASSIGNMENT_NET104Context context;
        AllRepositories<GioHangCT> gioHangCTRepos;
		AllRepositories<User> userRepos;

        public GioHangChiTietController()
        {
			context = new ASSIGNMENT_NET104Context();
			gioHangCTRepos = new AllRepositories<GioHangCT>(context, context.GioHangCTs);
			userRepos = new AllRepositories<User>(context, context.Users);
        }

        public IActionResult Index()
		{
            var loginData = HttpContext.Session.GetString("user");

            var userCart = context.GioHangCTs.Where(temp => temp.Id_User == Guid.Parse(loginData)).Include(temp => temp.SanPham).ToList();
            //var allData = context.GioHangCTs.Include(temp => temp.SanPham).ToList();

			if(userCart == null)
            {
                return Content("Bạn phải đăng nhập trước khi vào giỏ hàng");
            }
            
            return View(userCart);
		}

        /*
		 * var loginData = userRepos.GetAll().FirstOrDefault(p => p.TenDN == username && p.MatKhau == password);
            if (loginData == null)
            {
                return Content("Đăng nhập thất bại");
            }
            else
            {
                HttpContext.Session.SetString("user", loginData.Id.ToString());
                return RedirectToAction("IndexKH", "SanPham");
            }
		public IActionResult Update(Guid id)
		{
			var userCart = gioHangCTRepos.GetByID(id);
			return View(userCart);
		}
		[HttpPost]
        public IActionResult Update(GioHangCT gioHangCT)
        {
			gioHangCTRepos.UpdateObj(gioHangCT);
            return RedirectToAction("Index", "GioHangChiTiet");
        }

		*/
    }
}
