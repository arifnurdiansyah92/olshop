using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketplace.Data;
using Marketplace.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Marketplace.Controllers
{
    public class ProdukGambarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdukGambarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdukGambar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdukGambar.Include(p => p.Produk);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdukGambar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkGambar = await _context.ProdukGambar
                .Include(p => p.Produk)
                .SingleOrDefaultAsync(m => m.ProdukGambarId == id);
            if (produkGambar == null)
            {
                return NotFound();
            }

            return View(produkGambar);
        }

        // GET: ProdukGambar/Create
        public IActionResult Create()
        {
            ViewData["ProdukId"] = new SelectList(_context.Produk, "ProdukId", "ProdukId");
            return View();
        }

        // POST: ProdukGambar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdukGambar produkGambar, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null)

                {
                    if (Img.Length > 0)

                    //Convert Image to byte and save to database

                    {

                        byte[] p1 = null;
                        using (var fs1 = Img.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                        produkGambar.Gambar= String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(p1));

                    }
                }
                _context.Add(produkGambar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdukId"] = new SelectList(_context.Produk, "ProdukId", "ProdukId", produkGambar.ProdukId);
            return View(produkGambar);
        }

        // GET: ProdukGambar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkGambar = await _context.ProdukGambar.SingleOrDefaultAsync(m => m.ProdukGambarId == id);
            if (produkGambar == null)
            {
                return NotFound();
            }
            ViewData["ProdukId"] = new SelectList(_context.Produk, "ProdukId", "ProdukId", produkGambar.ProdukId);
            return View(produkGambar);
        }

        // POST: ProdukGambar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdukGambarId,Gambar,ProdukId,Thumbnail")] ProdukGambar produkGambar)
        {
            if (id != produkGambar.ProdukGambarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produkGambar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukGambarExists(produkGambar.ProdukGambarId))
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
            ViewData["ProdukId"] = new SelectList(_context.Produk, "ProdukId", "ProdukId", produkGambar.ProdukId);
            return View(produkGambar);
        }

        // GET: ProdukGambar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkGambar = await _context.ProdukGambar
                .Include(p => p.Produk)
                .SingleOrDefaultAsync(m => m.ProdukGambarId == id);
            if (produkGambar == null)
            {
                return NotFound();
            }

            return View(produkGambar);
        }

        // POST: ProdukGambar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produkGambar = await _context.ProdukGambar.SingleOrDefaultAsync(m => m.ProdukGambarId == id);
            _context.ProdukGambar.Remove(produkGambar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukGambarExists(int id)
        {
            return _context.ProdukGambar.Any(e => e.ProdukGambarId == id);
        }
    }
}
