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
	internal class HoaDonCT_Configuration : IEntityTypeConfiguration<HoaDonCT>
	{
		public void Configure(EntityTypeBuilder<HoaDonCT> builder)
		{
			builder.ToTable("HoaDonCT");

			builder.HasKey(a => a.Id);

			builder.HasOne(a => a.SanPham)
				.WithOne(a => a.HoaDonCT)
				.HasForeignKey<HoaDonCT>(a => a.Id_SP);

			builder.HasOne(a => a.HoaDon)
				.WithMany(a => a.HoaDonCTs)
				.HasForeignKey(a => a.Id_HoaDon);

			builder.Property(x => x.GiaBan).IsRequired();

			builder.Property(x => x.SLBan).IsRequired();
		}
	}
}
