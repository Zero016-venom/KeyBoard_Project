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
	internal class SanPham_Configuration : IEntityTypeConfiguration<SanPham>
	{
		public void Configure(EntityTypeBuilder<SanPham> builder)
		{
			builder.ToTable("SanPham");

			builder.HasKey(a => a.Id);

			builder.HasOne(a => a.LoaiSP)
				.WithMany(a => a.SanPhams)
				.HasForeignKey(a => a.Id_LoaiSP);

			builder.Property(x => x.TrangThai).IsRequired();

			builder.Property(x => x.MauSac).IsRequired().HasColumnType("nvarchar(30)");

			builder.Property(a => a.Ten).IsRequired().HasColumnType("nvarchar(50)");

		}
	}
}
