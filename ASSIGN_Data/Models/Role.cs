﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Models
{
	public class Role
	{
		public int Id { get; set; }
		public string? VaiTro { get; set; }

		public virtual ICollection<User> Users { get; set; }
	}
}
