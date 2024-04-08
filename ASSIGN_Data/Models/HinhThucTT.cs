using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class HinhThucTT
	{
		public Guid Id { get; set; }
		public string? TenHTTT { get; set; }
		public string? MoTa { get; set; }

		public virtual ICollection<ThanhToan> ThanhToans { get; set; }
	}
}
