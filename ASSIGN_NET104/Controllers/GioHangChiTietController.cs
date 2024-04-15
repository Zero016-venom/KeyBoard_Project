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

        public IActionResult ThanhToan()
        {
            var loginData = HttpContext.Session.GetString("user");
            var userCart = context.GioHangCTs.Where(temp => temp.Id_User == Guid.Parse(loginData)).ToList();

            foreach (var item in userCart)
            {
                var product = context.SanPhams.FirstOrDefault(temp => temp.Id == item.ID_SP);

                if(product != null)
                {
                    product.SLTon -= item.SoLuong;
                }
            }

            context.GioHangCTs.RemoveRange(userCart);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult Remove()
        //{
        //    var loginData = HttpContext.Session.GetString("user");
        //    var userCart = context.GioHangCTs.Where(temp => temp.Id_User == Guid.Parse(loginData)).ToList();

        //}
    }
}
