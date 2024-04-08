using ASSIGN_Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Configuration
{
	internal class GioHang_Configuration : IEntityTypeConfiguration<GioHang>
	{
		public void Configure(EntityTypeBuilder<GioHang> builder)
		{
			builder.ToTable("GioHang");

			builder.HasKey(a => a.Id_User);

			builder.HasOne(a => a.User)
				.WithOne(a => a.GioHang)
				.HasForeignKey<GioHang>(a => a.Id_User);

		}
	}
}
