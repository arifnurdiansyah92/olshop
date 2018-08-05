using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Produk
    {
        public int ProdukId { get; set; }
        public string Nama { get; set; }
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int StokLimit { get; set; }
        public string Deskripsi { get; set; }
        public List<ProdukGambar> Gambar { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public bool Status { get; set; }
    }

    public class Kategori
    {
        public int KategoriId { get; set; }
        public string Nama { get; set; }
        public List<Produk> Produk { get; set; }
        public string Ikon { get; set; }
        public bool Status { get; set; }
    }

    public class ProdukGambar
    {
        public int ProdukGambarId { get; set; }
        public string Gambar { get; set; }
        public int ProdukId { get; set; }
        public Produk Produk { get; set; }
        public bool Thumbnail { get; set; }
    }
}
