using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public int Id_Role { get; set; }
		public string TenDN { get; set; }
		public string MatKhau { get; set; }
		public string? Email { get; set; }
		public string? SDT { get; set; }
		public string? DiaChi { get; set; }
		public string HoTen { get; set; }
		public DateTime? NgaySinh { get; set; }

		public virtual ICollection<HoaDon> HoaDons { get; set; }
		public virtual GioHang GioHang { get; set; }
		public virtual Role Role { get; set; }
	}
}
