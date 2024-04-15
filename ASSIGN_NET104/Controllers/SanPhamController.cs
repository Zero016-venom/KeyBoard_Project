using ASSIGN_Data.Models;
using ASSIGN_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASSIGN_NET104.Controllers
{
    public class SanPhamController : Controller
    {
        AllRepositories<SanPham> sanPhamRepos;
        AllRepositories<GioHangCT> ghctRepos;
        ASSIGNMENT_NET104Context context;

        public SanPhamController()
        {
            context = new ASSIGNMENT_NET104Context();
            sanPhamRepos = new AllRepositories<SanPham>(context, context.SanPhams);
            ghctRepos = new AllRepositories<GioHangCT>(context, context.GioHangCTs);
        }
        public IActionResult Index()
        {
            var data = context.SanPhams.Include(a => a.LoaiSP).ToList();
            return View(data);
        }

        public IActionResult IndexKH()
        {
            var data = context.SanPhams.Include(a => a.LoaiSP).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            var loaiSP = context.LoaiSPs.ToList();
            ViewBag.LoaiSP = new SelectList(loaiSP, "Id", "TenLoaiSP");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SanPham sanPham, IFormFile imgFile)
        {
            if(imgFile != null && imgFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", imgFile.FileName);

                var stream = new FileStream(path, FileMode.Create);
                imgFile.CopyTo(stream);
                sanPham.Anh = imgFile.FileName;
            }
            else
            {
                sanPham.Anh = "";
            }
            
            sanPham.Id = Guid.NewGuid();
            sanPhamRepos.CreateObj(sanPham);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            var sanPham = sanPhamRepos.GetByID(id);

            var loaiSP = context.LoaiSPs.ToList();
            ViewBag.LoaiSP = new SelectList(loaiSP, "Id", "TenLoaiSP");

            return View(sanPham);
        }
        [HttpPost]
        public IActionResult Update(SanPham sanPham, IFormFile imgFile)
        {
            if (imgFile != null && imgFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", imgFile.FileName);

                var stream = new FileStream(path, FileMode.Create);
                imgFile.CopyTo(stream);
                sanPham.Anh = imgFile.FileName;
            } 

			sanPhamRepos.UpdateObj(sanPham);

			return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var sanPham = sanPhamRepos.GetByID(id);
            sanPhamRepos.DeleteObj(sanPham);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            var sanPham = sanPhamRepos.GetByID(id);

            var loaiSP = context.LoaiSPs.ToList();
            ViewBag.LoaiSP = new SelectList(loaiSP, "Id", "TenLoaiSP");

            return View(sanPham);
        }

		public IActionResult DetailsKH(Guid id)
		{
			var sanPham = sanPhamRepos.GetByID(id);

			var loaiSP = context.LoaiSPs.ToList();
			ViewBag.LoaiSP = new SelectList(loaiSP, "Id", "TenLoaiSP");

			return View(sanPham);
		}

        public IActionResult AddToCart(Guid id, int amount)
        {
            var loginData = HttpContext.Session.GetString("user");
            if (loginData == null)
            {
                return Content("Bạn phải đăng nhập trước khi mua sản phẩm");
            }
            else
            {
                var userCart = context.GioHangCTs.Where(temp => temp.Id_User == Guid.Parse(loginData)).ToList();
                bool checkSelected = false;
                Guid idGHCT = Guid.Empty;
                
                foreach (var item in userCart)
                {
                    if (item.ID_SP == id)
                    {
                        checkSelected = true;
                        idGHCT = item.Id_GHCT;
                        break;
                    }
                }

                if(!checkSelected)
                {
                    GioHangCT gioHangCT = new GioHangCT()
                    {
                        Id_GHCT = Guid.NewGuid(),
                        ID_SP = id,
                        Id_User = Guid.Parse(loginData),
                        SoLuong = amount,
                        TrangThai = 1
                    };

                    ghctRepos.CreateObj(gioHangCT);

                    return RedirectToAction("IndexKH");
                }
                else
                {
                    var ghctUpdate = context.GioHangCTs.Find(idGHCT);
                    ghctUpdate.SoLuong = ghctUpdate.SoLuong + amount;

                    ghctRepos.UpdateObj(ghctUpdate);

                    return RedirectToAction("IndexKH");
                }
            }
        }
    }
}
