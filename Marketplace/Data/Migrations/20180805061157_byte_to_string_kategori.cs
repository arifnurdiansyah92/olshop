using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Marketplace.Data.Migrations
{
    public partial class byte_to_string_kategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ikon",
                table: "Kategori",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Ikon",
                table: "Kategori",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
