using ASSIGN_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGN_Data.Configuration
{
	internal class Role_Configuration : IEntityTypeConfiguration<Role>

	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("Role");

			builder.HasKey(a => a.Id);

			builder.Property(x => x.VaiTro).IsRequired().HasColumnType("nvarchar(50)");
		}
	}
}
