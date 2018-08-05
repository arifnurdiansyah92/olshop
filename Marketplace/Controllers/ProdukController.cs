using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketplace.Data;
using Marketplace.Models;

namespace Marketplace.Controllers
{
    public class ProdukController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdukController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produk
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Produk.Include(p => p.Kategori).Include(x => x.Gambar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Produk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .Include(p => p.Kategori)
                .SingleOrDefaultAsync(m => m.ProdukId == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produk/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Set<Kategori>(), "KategoriId", "KategoriId");
            return View();
        }

        // POST: Produk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdukId,Nama,Harga,Stok,StokLimit,Deskripsi,KategoriId,Status")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Set<Kategori>(), "KategoriId", "KategoriId", produk.KategoriId);
            return View(produk);
        }

        // GET: Produk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk.SingleOrDefaultAsync(m => m.ProdukId == id);
            if (produk == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Set<Kategori>(), "KategoriId", "KategoriId", produk.KategoriId);
            return View(produk);
        }

        // POST: Produk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdukId,Nama,Harga,Stok,StokLimit,Deskripsi,KategoriId,Status")] Produk produk)
        {
            if (id != produk.ProdukId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.ProdukId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Set<Kategori>(), "KategoriId", "KategoriId", produk.KategoriId);
            return View(produk);
        }

        // GET: Produk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .Include(p => p.Kategori)
                .SingleOrDefaultAsync(m => m.ProdukId == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produk = await _context.Produk.SingleOrDefaultAsync(m => m.ProdukId == id);
            _context.Produk.Remove(produk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(int id)
        {
            return _context.Produk.Any(e => e.ProdukId == id);
        }
    }
}
