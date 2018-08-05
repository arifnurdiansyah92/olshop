using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Marketplace.Data.Migrations
{
    public partial class produk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Ikon = table.Column<byte[]>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Produk",
                columns: table => new
                {
                    ProdukId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Deskripsi = table.Column<string>(nullable: true),
                    Harga = table.Column<decimal>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Stok = table.Column<int>(nullable: false),
                    StokLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produk", x => x.ProdukId);
                    table.ForeignKey(
                        name: "FK_Produk_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdukGambar",
                columns: table => new
                {
                    ProdukGambarId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Gambar = table.Column<byte[]>(nullable: true),
                    ProdukId = table.Column<int>(nullable: false),
                    Thumbnail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdukGambar", x => x.ProdukGambarId);
                    table.ForeignKey(
                        name: "FK_ProdukGambar_Produk_ProdukId",
                        column: x => x.ProdukId,
                        principalTable: "Produk",
                        principalColumn: "ProdukId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produk_KategoriId",
                table: "Produk",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukGambar_ProdukId",
                table: "ProdukGambar",
                column: "ProdukId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdukGambar");

            migrationBuilder.DropTable(
                name: "Produk");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
