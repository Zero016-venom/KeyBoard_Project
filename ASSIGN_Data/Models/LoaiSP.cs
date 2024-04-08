using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class LoaiSP
	{
		public Guid Id { get; set; }
		public string? TenLoaiSP { get; set; }

		public virtual ICollection<SanPham> SanPhams { get; set; }
	}
}
