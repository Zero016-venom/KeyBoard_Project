using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASSIGN_Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HinhThucThanhToan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHTTT = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThanhToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenLoaiSP = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaiTro = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_LoaiSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaSP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SLTon = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSP_Id_LoaiSP",
                        column: x => x.Id_LoaiSP,
                        principalTable: "LoaiSP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Role = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    TenDN = table.Column<string>(type: "varchar(30)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    SDT = table.Column<string>(type: "varchar(15)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_Id_Role",
                        column: x => x.Id_Role,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_GioHang_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_HinhThucTT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangCT",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_SP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangCT", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_GioHangCT_GioHang_Id_User",
                        column: x => x.Id_User,
                        principalTable: "GioHang",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangCT_SanPham_ID_SP",
                        column: x => x.ID_SP,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_SP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_HoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SLBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_HoaDon_Id_HoaDon",
                        column: x => x.Id_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonCT_SanPham_Id_SP",
                        column: x => x.Id_SP,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_HoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_HTTT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayTT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhToan_HinhThucThanhToan_Id_HTTT",
                        column: x => x.Id_HTTT,
                        principalTable: "HinhThucThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToan_HoaDon_Id_HoaDon",
                        column: x => x.Id_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCT_ID_SP",
                table: "GioHangCT",
                column: "ID_SP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_Id_User",
                table: "HoaDon",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_Id_HoaDon",
                table: "HoaDonCT",
                column: "Id_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_Id_SP",
                table: "HoaDonCT",
                column: "Id_SP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_Id_LoaiSP",
                table: "SanPham",
                column: "Id_LoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_Id_HoaDon",
                table: "ThanhToan",
                column: "Id_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_Id_HTTT",
                table: "ThanhToan",
                column: "Id_HTTT");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id_Role",
                table: "User",
                column: "Id_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangCT");

            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HinhThucThanhToan");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "LoaiSP");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
