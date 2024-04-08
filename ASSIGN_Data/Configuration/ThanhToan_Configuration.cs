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
	internal class ThanhToan_Configuration : IEntityTypeConfiguration<ThanhToan>
	{
		public void Configure(EntityTypeBuilder<ThanhToan> builder)
		{
			builder.ToTable("ThanhToan");

			builder.HasKey(a => a.Id);

			builder.HasOne(a => a.HoaDon)
				.WithMany(a => a.ThanhToans)
				.HasForeignKey(a => a.Id_HoaDon);

			builder.HasOne(a => a.HinhThucTT)
				.WithMany(a => a.ThanhToans)
				.HasForeignKey(a => a.Id_HTTT);

			builder.Property(x => x.TrangThai).IsRequired().HasColumnType("int");

			builder.Property(x => x.NgayTT).IsRequired();
		}
	}
}
