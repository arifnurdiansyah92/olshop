using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Marketplace.Data.Migrations
{
    public partial class byte_to_string_produkgambar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gambar",
                table: "ProdukGambar",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Gambar",
                table: "ProdukGambar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
