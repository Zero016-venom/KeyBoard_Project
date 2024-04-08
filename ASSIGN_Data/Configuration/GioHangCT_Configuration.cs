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
	internal class GioHangCT_Configuration : IEntityTypeConfiguration<GioHangCT>
	{
		public void Configure(EntityTypeBuilder<GioHangCT> builder)
		{
			builder.ToTable("GioHangCT");

			builder.HasKey(a => a.Id_GHCT);

			builder.HasOne(a => a.GioHang)
				.WithMany(a => a.GioHangCTs)
				.HasForeignKey(a => a.Id_User);

			builder.HasOne(a => a.SanPham)
				.WithMany(a => a.GioHangCTs)
				.HasForeignKey(a => a.ID_SP);

			builder.Property(x => x.TrangThai).IsRequired();

			builder.Property(x => x.SoLuong).IsRequired();
		}
	}
}
