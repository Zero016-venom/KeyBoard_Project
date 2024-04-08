using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class HoaDonCT
	{
		public Guid Id { get; set; }
		public Guid Id_SP { get; set; }
		public Guid Id_HoaDon { get; set; }
		public decimal GiaBan { get; set; }
		public int SLBan { get; set; }

		public virtual SanPham SanPham { get; set; }
		public virtual HoaDon HoaDon { get; set; }
	}
}
