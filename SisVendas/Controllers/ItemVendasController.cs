using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisVendas.Models;

namespace SisVendas.Controllers
{
    public class ItemVendasController : Controller
    {
        private readonly SisVendasContext _context;

        public ItemVendasController(SisVendasContext context)
        {
            _context = context;
        }

        // GET: ItemVendas
        public async Task<IActionResult> Index()
        {
            var sisVendasContext = _context.ItemVendas.Include(i => i.Vendas);
            return View(await sisVendasContext.ToListAsync());
        }

        // GET: ItemVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVendas = await _context.ItemVendas
                .Include(i => i.Vendas)
                .FirstOrDefaultAsync(m => m.ItemVendasID == id);
            if (itemVendas == null)
            {
                return NotFound();
            }

            return View(itemVendas);
        }

        // GET: ItemVendas/Create
        public IActionResult Create()
        {
            ViewData["VendasId"] = new SelectList(_context.Vendas, "IdVenda", "IdVenda");
            return View();
        }

        // POST: ItemVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemVendasID,VendasId,ProdId,intQuant,douValor")] ItemVendas itemVendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendasId"] = new SelectList(_context.Vendas, "IdVenda", "IdVenda", itemVendas.VendasId);
            return View(itemVendas);
        }

        // GET: ItemVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVendas = await _context.ItemVendas.FindAsync(id);
            if (itemVendas == null)
            {
                return NotFound();
            }
            ViewData["VendasId"] = new SelectList(_context.Vendas, "IdVenda", "IdVenda", itemVendas.VendasId);
            return View(itemVendas);
        }

        // POST: ItemVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemVendasID,VendasId,ProdId,intQuant,douValor")] ItemVendas itemVendas)
        {
            if (id != itemVendas.ItemVendasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemVendasExists(itemVendas.ItemVendasID))
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
            ViewData["VendasId"] = new SelectList(_context.Vendas, "IdVenda", "IdVenda", itemVendas.VendasId);
            return View(itemVendas);
        }

        // GET: ItemVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemVendas = await _context.ItemVendas
                .Include(i => i.Vendas)
                .FirstOrDefaultAsync(m => m.ItemVendasID == id);
            if (itemVendas == null)
            {
                return NotFound();
            }

            return View(itemVendas);
        }

        // POST: ItemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemVendas = await _context.ItemVendas.FindAsync(id);
            _context.ItemVendas.Remove(itemVendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemVendasExists(int id)
        {
            return _context.ItemVendas.Any(e => e.ItemVendasID == id);
        }
    }
}
