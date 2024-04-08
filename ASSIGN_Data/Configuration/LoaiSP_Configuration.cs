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
	internal class LoaiSP_Configuration : IEntityTypeConfiguration<LoaiSP>
	{
		void IEntityTypeConfiguration<LoaiSP>.Configure(EntityTypeBuilder<LoaiSP> builder)
		{
			builder.ToTable("LoaiSP");

			builder.HasKey(a => a.Id);

			builder.Property(a => a.TenLoaiSP).IsRequired().HasColumnType("nvarchar(50)");

		}
	}
}
