using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASSIGN_Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GioHangCT",
                table: "GioHangCT");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_GHCT",
                table: "GioHangCT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GioHangCT",
                table: "GioHangCT",
                column: "Id_GHCT");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCT_Id_User",
                table: "GioHangCT",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GioHangCT",
                table: "GioHangCT");

            migrationBuilder.DropIndex(
                name: "IX_GioHangCT_Id_User",
                table: "GioHangCT");

            migrationBuilder.DropColumn(
                name: "Id_GHCT",
                table: "GioHangCT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GioHangCT",
                table: "GioHangCT",
                column: "Id_User");
        }
    }
}
