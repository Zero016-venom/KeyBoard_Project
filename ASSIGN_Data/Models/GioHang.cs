using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class GioHang
	{
		public Guid Id_User { get; set; }
		public decimal TongTien { get; set; }

		public virtual User User { get; set; }
		public virtual ICollection<GioHangCT> GioHangCTs { get; set; }
	}
}
