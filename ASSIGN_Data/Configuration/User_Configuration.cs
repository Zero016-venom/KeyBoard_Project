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
	internal class User_Configuration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");

			builder.HasKey(a => a.Id);

			builder.HasOne(a => a.Role)
				.WithMany(a => a.Users)
				.HasForeignKey(a => a.Id_Role);

			builder.Property(x => x.TenDN).IsRequired().HasColumnType("varchar(30)");

			builder.Property(x => x.MatKhau).IsRequired().HasColumnType("varchar(15)");

			builder.Property(x => x.Email).HasColumnType("varchar(50)");

			builder.Property(x => x.SDT).HasColumnType("varchar(15)");

			builder.Property(x => x.DiaChi).HasColumnType("nvarchar(200)");

			builder.Property(x => x.HoTen).HasColumnType("nvarchar(50)");

		}
	}
}
