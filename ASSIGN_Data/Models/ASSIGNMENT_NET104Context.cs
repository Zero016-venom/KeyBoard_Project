using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASSIGN_Data.Models
{
    public partial class ASSIGNMENT_NET104Context : DbContext
    {
        public ASSIGNMENT_NET104Context()
        {
        }

        public ASSIGNMENT_NET104Context(DbContextOptions<ASSIGNMENT_NET104Context> options)
            : base(options)
        {
        }

        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangCT> GioHangCTs { get; set; }
        public DbSet<HinhThucTT> HinhThucTTs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonCT> HoaDonCTs { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B52SRBN\\SQLEXPRESS;Database=ASSIGNMENT_NET104;Trusted_Connection=True; Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
