using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class SanPham
	{
		public Guid Id { get; set; }
		public Guid Id_LoaiSP { get; set; }
		public string? Ten { get; set; }
		public decimal GiaSP { get; set; }
		public int SLTon { get; set; }
		public int TrangThai { get; set; }
		public string? MauSac { get; set; }
		public string? Anh { get; set; }

		public virtual LoaiSP LoaiSP { get; set; }
		public virtual HoaDonCT HoaDonCT { get; set; }
		public virtual ICollection<GioHangCT> GioHangCTs { get; set; }
	}
}
